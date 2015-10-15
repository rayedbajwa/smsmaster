using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Helper
{
    public partial class add : Form
    {
        public add()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.Database1ConnectionString);
            SqlCommand com = new SqlCommand("select * from [dbo].[group]",con);
            con.Open();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read[1].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.Database1ConnectionString);
            try {
                con.Open();
                SqlCommand com = new SqlCommand("insert into [dbo].[contacts]"
                    +"(contact_number,description,group_id) values (@num,@desc,@id)",con);
                com.Parameters.AddWithValue("@num",textBox1.Text);
                com.Parameters.AddWithValue("@desc", textBox2.Text);
                com.Parameters.AddWithValue("@id", comboBox1.Text);
                com.ExecuteNonQuery();
                MessageBox.Show("added");
                this.Close();
            }

            catch(Exception err) {
                MessageBox.Show("error:" + err);
            }
        }
    }
}
