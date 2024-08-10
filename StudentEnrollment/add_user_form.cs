using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentEnrollment
{
    public partial class add_user_form : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-992JFUM\SQLEXPRESS;Initial Catalog=StudentEnrolment;Integrated Security=True");
        public SqlDataAdapter SqlDa = new SqlDataAdapter();
        public SqlCommand cmd = new SqlCommand();
        public DataSet Dset = new DataSet();
        public add_user_form()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id=txtNewUserName.Text;
            string password = txtNewPassword.Text;
            string recorretPassword = txtCorrectPassword.Text;
            bool isTrue= CheckId(id);
            try{
                // save new users
                if (isTrue == false)
                {
                    if (recorretPassword.Equals(password)) {
                        String sql = "INSERT INTO Login VALUES" + "('" + id + "','" + password + "')";
                        con.Open();
                        cmd = new SqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User Added Succesfully", "Register Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Password does not Same", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }catch(Exception ex)   
            {
                MessageBox.Show("User Name already added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

        }
        public bool CheckId(string id)
        {
            try
            {
                // search already add regNo
                //string sql = "SELECT  password  FROM Login WHERE userName='" + id + "'";
                string sql = "SELECT userName FROM Login";
                con.Open();
                cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                string checkIds="";
                while (dr.Read())
                {
                    checkIds = dr.GetValue(0).ToString();
                }
                if (id.Equals(checkIds))
                {
                    return true;
                }

               
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally {
               
                con.Close();
            }
            return false;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            login_form log = new login_form();
            log.Show();
            this.Hide();
        }
    }
}
