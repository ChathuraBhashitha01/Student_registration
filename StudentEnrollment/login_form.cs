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

namespace StudentEnrollment
{
    public partial class login_form : Form
    {
        public static string userName = " ";
        public static string password = " ";
        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-992JFUM\SQLEXPRESS;Initial Catalog=StudentEnrolment;Integrated Security=True");
        public SqlDataAdapter SqlDa = new SqlDataAdapter();
        public SqlCommand cmd = new SqlCommand();
        public DataSet Dset = new DataSet();
        public login_form()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string id = txtUserName.Text;
            string passwordGet = txtPassword.Text;
            
            //select user name and password
            string sql = "SELECT  password  FROM Login WHERE userName='" + id + "'";
            con.Open();
            cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                password = dr.GetValue(0).ToString();
            }

            if (password.Equals(passwordGet))
            { 
                registration_frm registration_Frm = new registration_frm();
                registration_Frm.Show();
                this.Hide();
               
            }
            else
            {
                MessageBox.Show("Invalid Login Credentials,please check Username and Password and try again", "Login Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPassword.Text=" ";
            txtUserName.Text=" ";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure,You want to Exit ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            add_user_form add=new add_user_form(); 
            add.Show();
            this.Hide();
        }
    }
}
