using GsmComm.GsmCommunication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS_project
{
    public partial class loadSettings : Form
    {
        public static Int16 Comm_Port = 0;
        public static Int32 Comm_BaudRate = 0;
        public static Int32 Comm_TimeOut = 0;
        public static GsmCommMain comm;
        public loadSettings(int c1,int c2,int c3)
        {
            InitializeComponent();
            Comm_Port = Convert.ToInt16(c1);
            Comm_BaudRate = c2;
            Comm_TimeOut = c3;
        }

        private void loadSettings_Load(object sender, EventArgs e)
        {
            comm = new GsmCommMain(Comm_Port, Comm_BaudRate, Comm_TimeOut);

            if (!comm.IsOpen())
            {
                comm.Open();
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
                MessageBox.Show("Error Retriving COM Port Phone Information"+e50.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
