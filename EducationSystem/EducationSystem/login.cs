using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EducationSystem
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=project;Integrated Security=True;Pooling=False");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from student where sname = '" + textBox2.Text.ToString() + "' and sadd = '" + textBox1.Text.ToString() + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                MDIParent1 md = new MDIParent1();
                md.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("login Failed");
            }
            con.Close();
        }
    }
}
