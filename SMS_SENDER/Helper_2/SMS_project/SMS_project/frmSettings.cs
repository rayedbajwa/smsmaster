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
using System.Threading;


namespace SMS_project
{
    public partial class frmSettings : Form
    {
        private DataTable dt = new DataTable();
        
       
     
        AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        static readonly object _locker = new object();
        Thread updatePortThread;
        public frmSettings()
        {
            InitializeComponent();
            updatePortThread = new Thread(new ThreadStart(refreshPorts));
            updatePortThread.Start();
               
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataGridViewCellStyle style = new DataGridViewCellStyle();

            style.Font = new Font(dataGridView3.Font, FontStyle.Bold);
            style.BackColor = Color.Green;
            style.ForeColor = Color.White;


            int i = dataGridView3.CurrentRow.Index;


            try
            {
                frmSMSmain.Comm_Port = Convert.ToInt16(listBox1.SelectedItem.ToString().Substring(3));

                frmSMSmain.Comm_BaudRate = Convert.ToInt32(listBox2.SelectedItem.ToString());

                frmSMSmain.Comm_TimeOut = Convert.ToInt32(dataGridView3.Rows[i].Cells[3].Value.ToString());
           //load   = new loadSettings(Comm_Port,Comm_BaudRate,Comm_TimeOut);
           
           //   load.Show();

            }
            catch (Exception E1)
            {
                MessageBox.Show("Error Converting COM Port Settings Values"+E1.Message.ToString(), "Check COM Port Values", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmSMSmain.comm = new GsmCommMain(frmSMSmain.Comm_Port, frmSMSmain.Comm_BaudRate, frmSMSmain.Comm_TimeOut);

            try
            {
                if (!frmSMSmain.comm.IsOpen())

                    frmSMSmain.comm.Open();
                if (frmSMSmain.comm.IsConnected())
                {

                   

                    MessageBox.Show("Connected Successfully To GSM Phone / Modem...!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView3.Rows[i].Cells[4].Value = "Connected";
                    dataGridView3.Rows[i].DefaultCellStyle = style;
                    dataGridView3.ClearSelection();
                   

                }

                


            }
            catch (Exception E2)
            {
                MessageBox.Show("Error While Connecting To GSM Phone / Modem/nError:" + E2.Message.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView3.ClearSelection();

            }
            //load.Close();
        }
        object captionObj;
        object capdeviceid;
        object MaxBaudRate;
        object connstatus;
        string timeoutsec;
        private void refreshPorts()
        {
            int i = 0;

            
            while (true)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_SerialPort");

                    foreach (ManagementObject queryObj in searcher.Get())
                    {

                        if (queryObj != null)
                        {
                            captionObj = queryObj["DESCRIPTION"];
                            capdeviceid = queryObj["DEVICEID"];
                            MaxBaudRate = queryObj["MAXBAUDRATE"];
                            connstatus = queryObj["STATUS"];
                            timeoutsec = "100";

                            addPort(capdeviceid);

                            i = 1;
                        }
                    }

                }

                catch (Exception e15)
                {
                    MessageBox.Show("An error occurred while querying for WMI data: " + e15.Message);
                }

                Cursor.Current = Cursors.Default;
                lock (_locker)
                {
                    if (i != 1)
                    {
                        autoResetEvent.Set();
                    }
                    else
                    {
                        autoResetEvent.Reset();
                        autoResetEvent.Dispose();
                       
                        updatePortThread.Abort();
                    }
                }
            }
           

            
        }
        private void addPort(object port)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new addPortDelegate(addPort), port);
            }
            else
            {
                dataGridView3.ColumnCount = 5;
                dataGridView3.Columns[0].Name = "COM Port";
                dataGridView3.Columns[1].Name = "Connected Device";
                dataGridView3.Columns[2].Name = "Max Baud Rate";
                dataGridView3.Columns[3].Name = "Time Out";
                dataGridView3.Columns[4].Name = "Status";
                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
               listBox1.Items.Add(port);
               dataGridView3.Rows.Add(capdeviceid, captionObj, MaxBaudRate, timeoutsec, connstatus);
               
                 
                Console.WriteLine("FOUND");
                
             
            }
        }
        private delegate void addPortDelegate(object s);
        private void frmSettings_Load(object sender, EventArgs e)
        {
            

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {int index;
            int i = dataGridView3.CurrentRow.Index;
            if (dataGridView3.Rows[i].Cells[0].Value.ToString() != string.Empty)
            {
                index = listBox1.FindString(dataGridView3.Rows[i].Cells[0].Value.ToString());
                if (index != -1)
                    listBox1.SetSelected(index, true);
            }
            if (dataGridView3.Rows[i].Cells[2].Value.ToString() != string.Empty)
            {
                index = listBox2.FindString(dataGridView3.Rows[i].Cells[2].Value.ToString());
                if (index != -1)
                    listBox2.SetSelected(index, true);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void frmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        public static String _MSGFor;
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            _MSGFor = this.Text.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _MSGFor = this.Text.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _MSGFor = this.Text.ToString();
        }
    }
}
