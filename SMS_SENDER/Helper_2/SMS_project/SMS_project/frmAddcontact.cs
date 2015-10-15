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
    public partial class frmAddcontact : Form
    {
        public frmAddcontact()
        {
            InitializeComponent();
        }

        private void frmAddcontact_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.database);
            SqlCommand com = new SqlCommand("select name from [dbo].[group]", con);
            con.Open();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                groupNames.Items.Add(read[0].ToString());
            }
            
            read.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id=0;
            SqlConnection con = new SqlConnection(Properties.Settings.Default.database);
            try
            {
                if (!(con.State == ConnectionState.Open))
                    con.Open();
                
                SqlCommand comId = new SqlCommand("select id from [dbo].[group] WHERE name LIKE '"+groupNames.Text+"'", con);
                SqlDataReader read2 = comId.ExecuteReader();
                while (read2.Read()) 
                {
                    id = Convert.ToInt16( read2[0].ToString());
                    Console.Write(id);
                }
                SqlCommand com = new SqlCommand("insert into [dbo].[contacts] (name,phone,address,telephone,email,group_id) values('" + name.Text + "','" + phone.Text + "','" + address.Text + "','" + tel.Text + "','" + email.Text + "',"+id+")", con);
               
                com.ExecuteNonQuery();
                read2.Close();
               
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
