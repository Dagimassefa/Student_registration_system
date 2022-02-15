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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-IOGAUF0\\SQLEXPRESS;Initial Catalog=student_reg;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 dbu = new Form1();
            this.Hide();
            dbu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string uid = txtid.Text;
                string name = txtname.Text;
                string desg = combodep.SelectedItem.ToString();
                string date = txtdate.Text;
                string amount = txtnum.Text;
                string id = txtmail.Text;
                con.Open();
                string qry = "insert into Finance(Payment_ID,student_name,department,dateofpayment,payed_amount,ID) values('" + uid + "','" + name + "','" + desg + "','" + date + "','" + amount + "','" + id + "')";
                SqlCommand cmd = new SqlCommand(qry, con);
                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
                {
                    MessageBox.Show(i + " Number of student Payed with username " + name);

                }
                else
                {
                    MessageBox.Show("student registeration failed with username " + name);
                    con.Close();
                    button1_Click(sender, e);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error Occured at student registration: " + ex.ToString());
            }
        }
    }
}
