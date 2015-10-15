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
    public partial class frmNewSMS : Form
    {
        private DataTable dt = new DataTable();
        public static Int16 Comm_Port = 0;
        public static Int32 Comm_BaudRate = 0;
        public static Int32 Comm_TimeOut = 0;
        public static GsmCommMain comm;
        DataSet dataSet, dataSet1 = new DataSet();
        SqlDataReader read;
        public frmNewSMS()
        {
            InitializeComponent();
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(Properties.Settings.Default.database);

        private void frmNewSMS_Load(object sender, EventArgs e)
        {
            try
            {
                if (!(con.State == ConnectionState.Open))
                    con.Open();


                SqlCommand com = new SqlCommand("select * from [dbo].[group]", con);

                read = com.ExecuteReader();
                while (read.Read())
                {

                    groupBox.Items.Add(read[1].ToString());
                }



            }
            catch (Exception er)
            {
            }
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {  int id=0;
            String num = Cell_Num.Text;
            String msg = SMS_Text.Text;
            if (groupBox.Text.Equals(string.Empty))
            {
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork +=(object sender1, DoWorkEventArgs er)=>
                {
                    sendSMS(num,msg);
                };
                bw.RunWorkerCompleted += (object sender2,RunWorkerCompletedEventArgs rr ) =>
                {   Console.Write("send single SMS Complete");
                };
                bw.RunWorkerAsync();
            
             
            }


            else
            {
                try {
                    if (!(con.State == ConnectionState.Open))
                        con.Open();
                    MessageBox.Show(groupBox.Text);
                    SqlCommand com = new SqlCommand("select id from [dbo].[group] where name LIKE '" + groupBox.Text + "'", con);
              
                    SqlDataReader readid = com.ExecuteReader();

                    while (readid.Read())
                    {
                        id = Convert.ToInt32(readid[0].ToString());
                    }
                    Console.Write("sending multiple async command");
                }catch(Exception rrr)
                {
                MessageBox.Show("read groupID: "+rrr);
                }
                try{
                    SqlCommand com1 = new SqlCommand("select phone from [dbo].[contacts] where group_id=" + id, con);
                    SqlDataReader read2 = com1.ExecuteReader();
                    
                     BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork +=(object sender1, DoWorkEventArgs er)=>
                {
                    while (read2.Read())
                    {
                        String num2 = read2[0].ToString();
                        sendSMS(num2, msg);
                    }
                   
                };
                bw.RunWorkerCompleted += (object sender2,RunWorkerCompletedEventArgs rr ) =>
                {   Console.Write("send mult SMS Complete");
                };
                bw.RunWorkerAsync();
                    }
                
                catch (Exception er) {

                    MessageBox.Show("read contacts: " + er);
                }

            }
        }



        public delegate void InvokeDelegate();


        public void sendSMS(String num, String msg)
        
        {
           
            SmsSubmitPdu pdu1;
            try{
                    if (comm.IsConnected() == true)
                    {
                        if (num == "")
                        {
                            MessageBox.Show("Kindly Add Cell Number\r\n\nFor Example\n\n+9231234567", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else if (msg == "")
                        {
                            MessageBox.Show("Kindly Add Your Message Text", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        

                        MessageBox.Show("Kindly Re-Check Your SMS & CELL NUMBER \r\n\nCELL # : " + num + "\r\n\nMESSAGE TEXT : " +msg, "SMS INFO", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            pdu1 = new SmsSubmitPdu(msg, num, "");

                            comm.SendMessage(pdu1);

                            Cursor.Current = Cursors.Default;

                            MessageBox.Show("M E S S A G E - S E N T", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                        catch (Exception E5)
                        {

                            MessageBox.Show("Error Sending SMS To Destination Address\r\n\n Connection Has Been Terminated !!!\r\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
