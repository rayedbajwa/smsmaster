using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GsmComm.GsmCommunication;
using GsmComm.Interfaces;
using GsmComm.PduConverter;
using GsmComm.Server;
using System.IO;
using System.Data.OleDb;
using System.Management;
using System.Data.SqlClient;
using System.Timers;


namespace Helper
{
    public partial class Form1 : Form
    {
        private DataTable dt = new DataTable();
        public static Int16 Comm_Port = 0;
        public static Int32 Comm_BaudRate = 0;
        public static Int32 Comm_TimeOut = 0;
        public static GsmCommMain comm;
        DataSet dataSet, dataSet1 = new DataSet();
        
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            string CELL_Number, SMS_Message;

            SmsSubmitPdu pdu1;

            try
            {

                if (comm.IsConnected() == true)
                {
                    if (Cell_Num.Text.ToString() == "")
                    {
                        MessageBox.Show("Kindly Add Cell Number\r\n\nFor Example\n\n+9231234567", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else if (SMS_Text.Text.ToString() == "")
                    {
                        MessageBox.Show("Kindly Add Your Message Text", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    CELL_Number = Cell_Num.Text.ToString();
                    SMS_Message = SMS_Text.Text.ToString();

                    MessageBox.Show("Kindly Re-Check Your SMS & CELL NUMBER \r\n\nCELL # : " + CELL_Number + "\r\n\nMESSAGE TEXT : "+SMS_Message ,"SMS INFO", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        pdu1 = new SmsSubmitPdu(SMS_Message, CELL_Number, "");

                        comm.SendMessage(pdu1);

                        Cursor.Current = Cursors.Default;

                        MessageBox.Show("M E S S A G E - S E N T", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                    catch (Exception E5)
                    {

                        MessageBox.Show("Error Sending SMS To Destination Address\r\n\n Connection Has Been Terminated !!!\r\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        comm.Close();
                        pictureBox3.Image = imageList1.Images[0];
                        button9.Enabled = true;
                        button10.Enabled = false;
                        Single_SMS.Enabled = false;
                        button4.Enabled = false;
                        button7.Enabled = false;
                        dataGridView3.Rows.Clear();
                        Phone_Model.Text = ".....";
                        Phone_Name.Text = ".....";
                        Revision_Num.Text = ".....";
                        Serial_Num.Text = ".....";

                    }

                    
                }
                else
                {
                    MessageBox.Show("No GSM Phone / Modem Connected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception E10)
            {
                MessageBox.Show("CONNECTION ERROR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }           

        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
           
            button10.Enabled = false;
         
        }



        private void button3_Click_1(object sender, EventArgs e)
        {

            int rows_counting, column_counting1 = 0;

            OpenFileDialog dialog = new OpenFileDialog { };

            dialog.Filter = "SMS Sending File(*.xlsx;*.xls)|*.xlsx;*.xls";

            dialog.Title = "Select Excel File For SMS";

            DialogResult dlgresult = dialog.ShowDialog();

            if (dlgresult == DialogResult.Cancel)
            {
                MessageBox.Show("You Press Cancelled :-) !!!");
            }
            else
            {
                string sms_filename = dialog.FileName;

                if (System.IO.File.Exists(sms_filename))
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        string connectionString = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""", sms_filename);

                        string query = String.Format("select * from [{0}$]", "SMS");

                        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString);

                        dataSet = new DataSet();

                        dataAdapter.Fill(dataSet);

                        dataGridView1.DataSource = dataSet.Tables[0];

                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                        rows_counting = dataGridView1.RowCount - 1;                                            
                        
                        column_counting1 = dataGridView1.ColumnCount;

                        if (column_counting1 < 2 || column_counting1 > 2)
                        {
                            MessageBox.Show("Kindly Check Column Count in Excel Sheet !!!\r\n\nThere Should Be Only Two Columns in Sheet Like Below\r\n\nCELL NUMBER | MESSAGE", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                            
                            return;
                        }

                        if (    dataGridView1.Columns[0].Name.ToString().ToUpper() == "CELL NUMBER" &&
                                dataGridView1.Columns[1].Name.ToString().ToUpper() == "MESSAGES")

                        {
                            label25.Text = "Total SMS In Excel File " + rows_counting;
                            MessageBox.Show("Data Imported Successfully...!!!\r\n\nCheck Imported Values & SEND SMS.....!!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            button7.Enabled = true;
                            button4.Enabled = true;

                            Cursor.Current = Cursors.Default;
                        }
                        else
                        {
                            MessageBox.Show("Column Names Are Not In Specified Format !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        

                    }
                    catch (Exception E6)
                    {
                        MessageBox.Show("Error Loading Excel FIle\r\n\nKindly Check Worksheet Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }




                }
            }


        }


        private void button4_Click(object sender, EventArgs e)
        {
            string MSMS_Number, MMessage;

            int i;

            SmsSubmitPdu pdu3;
            try
            {
                if (comm.IsConnected()==true)

                    {

                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            for (i = 0; i < dataGridView1.RowCount - 1; i++)
                            {

                                MSMS_Number = dataGridView1.Rows[i].Cells[0].Value.ToString();
                                MMessage = dataGridView1.Rows[i].Cells[1].Value.ToString();


                                pdu3 = new SmsSubmitPdu(MMessage, MSMS_Number, "");

                                comm.SendMessage(pdu3);

                                //Sleeps system for 1000ms for refreshing GSM Modem

                                System.Threading.Thread.Sleep(1000);
                            }
                            
                        Cursor.Current = Cursors.Default;

                        MessageBox.Show("T O T A L - M E S S A G E - S E N T = " + i, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        catch(Exception E23)
                                {
                                    MessageBox.Show("Error Sending SMS To Destination Address\r\n\n Connection Has Been Terminated !!!\r\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    comm.Close();
                                    pictureBox3.Image = imageList1.Images[0];
                                    button9.Enabled = true;
                                    button10.Enabled = false;
                                    dataGridView3.Rows.Clear();
                                    dataSet.Clear();
                                    dataGridView1.Refresh();
                                    button4.Enabled = false;
                                    button7.Enabled = false;
                                    Single_SMS.Enabled = false;
                                    Phone_Model.Text = ".....";
                                    Phone_Name.Text = ".....";
                                    Revision_Num.Text = ".....";
                                    Serial_Num.Text = ".....";

                                }
                        }
                else
                {
                    MessageBox.Show("No GSM Phone / Modem Connected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button4.Enabled = false;
                    button7.Enabled = false;
                    return;
                }
                                                                                    

                }
                catch (Exception E7)
                {

                    label25.Text = "M U L T I P L E  -  S M S  -  I N F O";
                    dataSet.Clear();
                    dataGridView1.Refresh();
                    button4.Enabled = false;
                    button7.Enabled = false;
                    MessageBox.Show("Error Sending SMS Messages\r\n\nKindly Check Connection\n\nNetwork Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                    

                }


        }
        

        private void button7_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount ; j++)
                {
                    if (    dataGridView1.Rows[i].Cells[j].Value.ToString() == "" ||                        
                            dataGridView1.Rows[i].Cells[j].Value.ToString().ToUpper() == "-" ||
                            dataGridView1.Rows[i].Cells[j].Value.ToString().Length > 160 )

                        //Setting Cells Background color to RED if above Error Found in Any of the cells

                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Red;

                        //Setting Cells Background color to GREEN which passes above validations

                    else

                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Green;
                        button4.Enabled = true;


                }
            }
        }
        

        private void label30_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(":-)\r\n\nLet The SMS Begin...!!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        

        private void button9_Click(object sender, EventArgs e)
        {
            //Setting the column grid for fetched data

            dataGridView3.ColumnCount = 5;
            dataGridView3.Columns[0].Name = "COM Port";
            dataGridView3.Columns[1].Name = "Connected Device";
            dataGridView3.Columns[2].Name = "Max Baud Rate";
            dataGridView3.Columns[3].Name = "Time Out";
            dataGridView3.Columns[4].Name = "Status";
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_SerialPort");                                       

                foreach (ManagementObject queryObj in searcher.Get())
                {

                    if (queryObj != null)
                    {
                        object captionObj = queryObj["DESCRIPTION"];
                        object capdeviceid = queryObj["DEVICEID"];
                        object MaxBaudRate = queryObj["MAXBAUDRATE"];
                        object connstatus = queryObj["STATUS"];
                        string timeoutsec = "100";

                            dataGridView3.Rows.Add(capdeviceid, captionObj, MaxBaudRate, timeoutsec, connstatus);


                    }
                }

            }

            catch (Exception e15)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e15.Message);
            }

            Cursor.Current = Cursors.Default;
            button9.Enabled = false;
            button10.Enabled = true;

           
        }
        

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewCellStyle style = new DataGridViewCellStyle();

            style.Font = new Font(dataGridView3.Font, FontStyle.Bold);            
            style.BackColor = Color.Green;
            style.ForeColor = Color.White;
            

                int i = dataGridView3.CurrentRow.Index;
                

                try
                {
                    Comm_Port =     Convert.ToInt16(dataGridView3.Rows[i].Cells[0].Value.ToString().Substring(3));
                    Comm_BaudRate = Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value.ToString());
                    Comm_TimeOut =  Convert.ToInt32(dataGridView3.Rows[i].Cells[3].Value.ToString());
                }
                catch (Exception E1)
                {
                    MessageBox.Show("Error Converting COM Port Settings Values", "Check COM Port Values", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                comm = new GsmCommMain(Comm_Port, Comm_BaudRate, Comm_TimeOut);

                try
                {

                        comm.Open();
                        if (comm.IsConnected())
                        {

                            pictureBox3.Image = imageList1.Images[1];

                            MessageBox.Show("Connected Successfully To GSM Phone / Modem...!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridView3.Rows[i].Cells[4].Value = "Connected";
                            dataGridView3.Rows[i].DefaultCellStyle = style;
                            dataGridView3.ClearSelection();
                            Single_SMS.Enabled = true;

                        }

                        try
                        {
                            Phone_Name.Text = comm.IdentifyDevice().Manufacturer.ToUpper().ToString();
                            Phone_Model.Text = comm.IdentifyDevice().Model.ToUpper().ToString();
                            Revision_Num.Text = comm.IdentifyDevice().Revision.ToUpper().ToString();
                            Serial_Num.Text = comm.IdentifyDevice().SerialNumber.ToUpper().ToString();
                        }
                        catch (Exception e50)
                        {
                            MessageBox.Show("Error Retriving COM Port Phone Information"+e50, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    

                }
                catch (Exception E2)
                {
                    MessageBox.Show("Error While Connecting To GSM Phone / Modem"+E2, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView3.ClearSelection();

                }
        }


        private void button10_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!comm.IsConnected())
                {
                    MessageBox.Show("No Phone Connected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {

                    comm.Close();
                    pictureBox3.Image = imageList1.Images[0];
                    button9.Enabled = true;
                    button10.Enabled = false;
                    Single_SMS.Enabled = false;
                    button4.Enabled = false;
                    button7.Enabled = false;
                    dataGridView3.Rows.Clear();
                    Phone_Model.Text = ".....";
                    Phone_Name.Text = ".....";
                    Revision_Num.Text = ".....";
                    Serial_Num.Text = ".....";
                    MessageBox.Show("Disconnected Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

            catch (Exception No_Conn)
            {

                MessageBox.Show("No Phone Connected!!" + No_Conn, "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
        

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (comm.IsOpen() == true)
                {                    
                    comm.Close();
                }
            }
            catch (Exception E16)
            {               
                Application.Exit();
            }

            Application.Exit();
        }
        

        private void SMS_Text_TextChanged(object sender, EventArgs e)
        {
            label4.Text = "Characters Left : "+(160 - SMS_Text.Text.Length).ToString();
        }

        private void read_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            string storage = GetMessageStorage();

            try
            {
                // Read all SMS messages from the storage

                DecodedShortMessage[] messages = comm.ReadMessages(PhoneMessageStatus.All, storage);
                foreach (DecodedShortMessage message in messages)
                {
                    Output(string.Format("Message status = {0}, Location = {1}/{2}",
                        StatusToString(message.Status), message.Storage, message.Index));
                    ShowMessage(message.Data);
                    Output("");
                }
                Output(string.Format("{0,9} messages read.", messages.Length.ToString()));
                Output("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Cursor.Current = Cursors.Default;
        }

      
        private void BindGrid(SmsPdu pdu)
        {
           
            DataRow dr = dt.NewRow();
            SmsDeliverPdu data = (SmsDeliverPdu)pdu;

            dr[0] = data.OriginatingAddress.ToString();
            dr[1] = data.SCTimestamp.ToString();
            dr[2] = data.UserDataText;
            
            dt.Rows.Add(dr);

            smsgrid.DataSource = dt;
        }
        private string StatusToString(PhoneMessageStatus status)
        {
            // Map a message status to a string
            string ret;
            switch (status)
            {
                case PhoneMessageStatus.All:
                    ret = "All";
                    break;
                case PhoneMessageStatus.ReceivedRead:
                    ret = "Read";
                    break;
                case PhoneMessageStatus.ReceivedUnread:
                    ret = "Unread";
                    break;
                case PhoneMessageStatus.StoredSent:
                    ret = "Sent";
                    break;
                case PhoneMessageStatus.StoredUnsent:
                    ret = "Unsent";
                    break;
                default:
                    ret = "Unknown (" + status.ToString() + ")";
                    break;
            }
            return ret;
        }


        private string GetMessageStorage()
        {
            string storage = string.Empty;
            if (rbMessageSIM.Checked)
                storage = PhoneStorageType.Sim;
            if (rbMessagePhone.Checked)
                storage = PhoneStorageType.Phone;
            if (storage.Length == 0)
                throw new ApplicationException("Unknown message storage.");
            else
                return storage;
        }
        


        private void Receive_Load(object sender, System.EventArgs e)
        {
            dt.Columns.Add("Sender", typeof(string));
            dt.Columns.Add("Time", typeof(string));
            dt.Columns.Add("Message", typeof(string));
        }

        private void Output(string text, params object[] args)
        {
            string msg = string.Format(text, args);
            Output(msg);
        }

        private void ShowMessage(SmsPdu pdu)
        {
            if (pdu is SmsSubmitPdu)
            {
                // Stored (sent/unsent) message
                SmsSubmitPdu data = (SmsSubmitPdu)pdu;
                Output("SENT/UNSENT MESSAGE");
                Output("Recipient: " + data.DestinationAddress);
                Output("Message text: " + data.UserDataText);
                Output("-------------------------------------------------------------------");
                BindGrid(pdu);
                return;
            }
            if (pdu is SmsDeliverPdu)
            {
                // Received message
                SmsDeliverPdu data = (SmsDeliverPdu)pdu;
                Output("RECEIVED MESSAGE");
                Output("Sender: " + data.OriginatingAddress);
                Output("Sent: " + data.SCTimestamp.ToString());
                Output("Message text: " + data.UserDataText);
                Output("-------------------------------------------------------------------");

                BindGrid(pdu);

                return;
            }
            if (pdu is SmsStatusReportPdu)
            {
                // Status report
                SmsStatusReportPdu data = (SmsStatusReportPdu)pdu;
                Output("STATUS REPORT");
                Output("Recipient: " + data.RecipientAddress);
                Output("Status: " + data.Status.ToString());
                Output("Timestamp: " + data.DischargeTime.ToString());
                Output("Message ref: " + data.MessageReference.ToString());
                Output("-------------------------------------------------------------------");
                return;
            }
            Output("Unknown message type: " + pdu.GetType().ToString());
        }
        private void Output(string text)
        {
            if (this.txtOutput.InvokeRequired)
            {
                SetTextCallback stc = new SetTextCallback(Output);
                this.Invoke(stc, new object[] { text });
            }
            else
            //{
                txtOutput.AppendText(text);
                txtOutput.AppendText("\r\n");
            }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.Database1ConnectionString);
          
            SqlDataAdapter adap = new SqlDataAdapter("select * from contacts",con);
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                adap.Fill(dt);
                dataGridView1.DataSource = dt;
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                dataGridView1.Columns.Add(chk);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                chk.HeaderText="Select Receipients";
                button1.Enabled = false;
                button7.Enabled = true;
            }
            catch (Exception er)
            {
                Console.Write("" + er);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add newMDI = new add();
            
            newMDI.Show();
        }

        private void smsgrid_CellClick(object sender, MouseEventArgs e)
        {
            Output(e.ToString());
            return;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Phone_Name_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void Phone_Model_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void Revision_Num_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Serial_Num_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
        }
        delegate void SetTextCallback(string text);
    

 
    


    


        }
