using GsmComm.GsmCommunication;
using GsmComm.PduConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS_project
{
    public partial class frmSMSmain : Form
    {
        private DataTable dt = new DataTable();
        public static Int16 Comm_Port = 0;
        public static Int32 Comm_BaudRate = 0;
        public static Int32 Comm_TimeOut = 0;
        public static GsmCommMain comm;
        DataSet dataSet, dataSet1 = new DataSet();
        
        public frmSMSmain()
        {
            InitializeComponent();
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmSMSmain_Load(object sender, EventArgs e)
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
            SqlConnection con = new SqlConnection(Properties.Settings.Default.database);
          
            SqlDataAdapter adap = new SqlDataAdapter("select * from contacts",con);
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                adap.Fill(dt);
                smsgrid.DataSource = dt;
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                smsgrid.Columns.Add(chk);
                smsgrid.Columns[0].Visible = false;
                smsgrid.Columns[2].Visible = false;
                chk.HeaderText="Select Receipients";
              
            }
            catch (Exception er)
            {
                Console.Write("" + er);
            }
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
        
        delegate void SetTextCallback(string text);
    

 
    

        

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
 
   
        }

        private void messageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

       
        private void rbMessageSIM_CheckedChanged(object sender, EventArgs e)
        {
            frmSMSmain_Load(sender,e);
        }

        private void rbMessagePhone_CheckedChanged(object sender, EventArgs e)
        {
            frmSMSmain_Load(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmSettings try1= new frmSettings();
                try1.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(Properties.Settings.Default.database);
        private void load_groups(object sender, EventArgs e)
        {
            try {
                if (!(con.State == ConnectionState.Closed))
                    con.Open();
                SqlDataAdapter com = new SqlDataAdapter("select * from [dbo].[group]",con);
                DataTable dt = new DataTable();
                com.Fill(dt);

                groupsGrid.DataSource = dt;
                groupsGrid.Columns[1].HeaderText = "Name";
                groupsGrid.Columns[1].HeaderText = "Description";
                groupsGrid.Columns[0].Visible = false;
                groupsGrid.Columns.Add("totalCon","Total Contacts");
                groupsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch(Exception er)
            {
                MessageBox.Show("Error: " + er);
            }
        }

        private void l(object sender, EventArgs e)
        {

        }

        private void conGrid_laod(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmAddcontact add = new frmAddcontact();
            add.Show();
        }

        private void contactGrid_load(object sender, EventArgs e)
        {
            try
            {
                if (!(con.State == ConnectionState.Closed))
                    con.Open();
                SqlDataAdapter com = new SqlDataAdapter("select * from [dbo].[contacts]", con);
                DataTable dt = new DataTable();
                com.Fill(dt);

                contactGrid.DataSource = dt;

                contactGrid.Columns[0].Visible = false;
                contactGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er);
            }
        }
        int searchConById;
        private void selectContact(object sender, DataGridViewCellEventArgs e)
        {
            searchConById=  Convert.ToInt32( contactGrid[0,e.RowIndex].Value);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            frmEditcontact editCon = new frmEditcontact(searchConById);
            editCon.Show();
        }
        int searchGrById;

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            frmEditGroup editGroup = new frmEditGroup(searchGrById);
            editGroup.Show();
        }

        private void groupSelect(object sender, DataGridViewCellEventArgs e)
        {
            searchGrById = Convert.ToInt32(groupsGrid[0, e.RowIndex].Value);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(con.State == ConnectionState.Closed))
                    con.Open();
                SqlCommand com = new SqlCommand("delete from [dbo].[group] where id="+searchGrById, con);
                int numRec= com.ExecuteNonQuery();
                if (numRec > 0)
                {
                    MessageBox.Show("Deleted.");
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            frmNewSMS newSMS = new frmNewSMS();
            newSMS.Show();
        }
    }
}
