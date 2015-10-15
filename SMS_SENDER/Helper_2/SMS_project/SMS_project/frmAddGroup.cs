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
    public partial class frmAddGroup : Form
    {
        public frmAddGroup()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(Properties.Settings.Default.database);

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (!(con.State == ConnectionState.Open))
                    con.Open();
                SqlCommand com = new SqlCommand("insert into [dbo].[group] (name,description) values('"+groupName.Text+"','"+descText.Text+"')",con);
                com.ExecuteNonQuery();
                MessageBox.Show(groupName.Text + " added.");
            }

            catch (Exception err)
            {
                MessageBox.Show("as: " + err);
            }
            finally
            {
                con.Close();
            }

        }
    }
}
