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
   
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }
       

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-IOGAUF0\\SQLEXPRESS;Initial Catalog=student_reg;Integrated Security=True");
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                string uid = txtid.Text;
                string name = txtname.Text;
                string desg = combodesign.SelectedItem.ToString();
                string dep = combodep.SelectedItem.ToString();
                string number = txtnum.Text;
                string email = txtmail.Text;
                string uname = txtuname.Text;
                string pass = txtpassword.Text;
                con.Open();
                string qry = "insert into Student(ID,Name,Designation,Department,Mobile_number,Email,User_name,Password) values('"+uid+"','"+ name + "','"+ desg + "','"+ dep + "','"+ number + "','"+ email + "','"+ uname + "','"+ pass + "')";
                SqlCommand cmd = new SqlCommand(qry,con);
               int i= cmd.ExecuteNonQuery();
                if (i >= 1)
                {
                    MessageBox.Show(i + "Number of student registered with username " + name);

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
                MessageBox.Show("Error Occured at student registration: "+ex.ToString());
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.txtid.Text = "";
            this.txtname.Text = "";
            this.txtmail.Text = "";
            this.txtnum.Text = "";
            this.txtpassword.Text = "";
            this.txtuname.Text = "";
            this.combodep.SelectedIndex = -1;
            this.combodesign.SelectedIndex = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 r = new Form1();
            r.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 update = new Form3();
            this.Hide();
            update.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Students_List list = new Students_List();
            this.Hide();
            list.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListOfStudPay list = new ListOfStudPay();
            this.Hide();
            list.Show();
        }
    }
}
