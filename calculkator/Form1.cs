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

namespace calculkator
{

    public partial class Form1 : Form
    {
        Function fn = new Function();
        public Form1()
        {
            InitializeComponent();
          
        }
        class Function
        {
            protected SqlConnection getConnection()
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=DESKTOP-IOGAUF0\\SQLEXPRESS;Initial Catalog=student_reg;Integrated Security=True";
                return con;
            }
            public DataSet getData(string query)
            {
                SqlConnection con = getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            public void setData(string query, string message)
            {
                SqlConnection con = getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(" '" + message + "' ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            public SqlDataReader getForCombo(string query)
            {
                SqlConnection con = getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                return sdr;
            }
        }
        // SqlConnection con = new SqlConnection("Data Source=DESKTOP-IOGAUF0\\SQLEXPRESS;Initial Catalog=student_reg;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            
            string name = txtusername.Text.ToString();
            string pass = txtpassword.Text.ToString();
            //con.Open();
            string query = "select Reg_Id,Password from Registrar where Reg_Id='" + name + "' and Password='" + pass + "'";
            /*SqlDataAdapter sda = new SqlDataAdapter(qry, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Valid User..." + name);
            }
            else
            {
                MessageBox.Show("Invalid user..." + name);
                con.Close();
                button1_Click_1(sender, e);
            }*/
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count != 0)
            {
                Form2 dbu = new Form2();
                this.Hide();
                dbu.Show();
                labelError.Visible = false;
            }
            else
            {
                txtpassword.Clear();
                labelError.Visible = true;
            }



        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
           
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.txtusername.Text = "";
            this.txtpassword.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 r = new Form2();
            r.Show();
        }

        private void labelError_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form5 dbu = new Form5();
            this.Hide();
            dbu.Show();
        }
    }
}
