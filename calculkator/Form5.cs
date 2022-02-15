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
    public partial class Form5 : Form
    {
        Function fn = new Function();
        public Form5()
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.txtusername.Text = "";
            this.txtpassword.Text = "";
        }

        private void Product_Click(object sender, EventArgs e)
        {
            string name = txtusername.Text.ToString();
            string pass = txtpassword.Text.ToString();
            string query = "select Fin_ID,Fin_name from Finance_Worker where Fin_ID='" + name + "' and Fin_name='" + pass + "'";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count != 0)
            {
                Form4 dbu = new Form4();
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
       
    }
}
