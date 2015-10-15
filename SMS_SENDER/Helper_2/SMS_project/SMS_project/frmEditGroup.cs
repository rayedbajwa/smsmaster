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
    public partial class frmEditGroup : Form
    {
       int searchById;
        public frmEditGroup(int id)
        
        {

           
            InitializeComponent();
            searchById = id;
            
        }
        SqlConnection con = new SqlConnection(Properties.Settings.Default.database);
        private void frmEditGroup_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand com = new SqlCommand("select name,description from [dbo].[group] where id= " + searchById , con);
                con.Open();
                SqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    groupNames.Text = read[0].ToString();
                    desc.Text = read[1].ToString();
                }

                read.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString());
            }
        }

        private void groupNames_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
