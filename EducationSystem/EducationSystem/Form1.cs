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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=project;Integrated Security=True;Pooling=False");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            comboBox1.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           try
           {
                con.Open();
                string name = textBox2.Text.ToString();
                string address = textBox3.Text.ToString();
                string phone = textBox4.Text.ToString();
                long phn = Int64.Parse(phone);
                string sem = textBox5.Text.ToString();
                int isem = Int32.Parse(sem);
                string branch = comboBox1.SelectedItem.ToString();

                string query = "insert into student values('" + name + "','" + address + "'," + phn + "," + isem + ",'" + branch + "')";
                SqlCommand sc = new SqlCommand(query, con);

                int i = sc.ExecuteNonQuery();
                if (i >= 0)
                    MessageBox.Show(i + " Student is registered as: " + name);
                else
                    MessageBox.Show("Registration Failed!");

                button1_Click(sender, e);
                show();
                con.Close();

           }catch(System.Exception exp)
           {
                MessageBox.Show("Error is: " + exp.ToString());
           }
        }

        void show()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from student", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr[4].ToString();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string name = textBox2.Text.ToString();
                string address = textBox3.Text.ToString();
                string phone = textBox4.Text.ToString();
                long phn = Int64.Parse(phone);
                string sem = textBox5.Text.ToString();
                int isem = Int32.Parse(sem);
                string branch = comboBox1.SelectedItem.ToString();

                string query = "update student set sname='" + name + "',sadd='" + address + "',phone=" + phn + ",sem=" + isem + ",branch='" + branch + "' where sname='"+name+"'";
                SqlCommand sc = new SqlCommand(query, con);

                int i = sc.ExecuteNonQuery();
                if (i >= 0)
                    MessageBox.Show(" update successful");
                else
                    MessageBox.Show("update Failed!");

                button1_Click(sender, e);
                show();
                con.Close();

            }
            catch (System.Exception exp)
            {
                MessageBox.Show("Error is: " + exp.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string name = textBox2.Text.ToString();
                string query = "delete from student where sname='"+name+"'";

                SqlCommand sc = new SqlCommand(query, con);

                int i = sc.ExecuteNonQuery();
                if (i >= 0)
                    MessageBox.Show("successfully delted");
                else
                    MessageBox.Show("Deletion Failed!");

                button1_Click(sender, e);
                show();
                con.Close();

            }
            catch (System.Exception exp)
            {
                MessageBox.Show("Error is: " + exp.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from student where sname like '%"+textBox1.Text.ToString()+"%'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr[4].ToString();
            }
            con.Close();
        }
    }
}
