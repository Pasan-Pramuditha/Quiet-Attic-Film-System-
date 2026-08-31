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

namespace Quiet_Attic_Films
{
    public partial class LoginForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True");

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Clear()
        {

            texPassword.Clear();
            texUsername.Clear();
            texUsername.Focus();

        }



        private void pictureBox11_Click(object sender, EventArgs e)
        {
            SelectAdEmp log = new SelectAdEmp();
            this.Hide();
            log.Show();
        }

        private void butLogin_Click_1(object sender, EventArgs e)
        {
            {

                string username = texUsername.Text;
                string password = texPassword.Text;


                string query = "SELECT COUNT(*) FROM Employee WHERE User_Name = @UserName AND Password = @Password";



                {
                    con.Open();


                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        cmd.Parameters.AddWithValue("@UserName", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        int result = Convert.ToInt32(cmd.ExecuteScalar());


                        if (result > 0)
                        {
                            MessageBox.Show("Login successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            EmployeeForm log = new EmployeeForm();
                            this.Hide();
                            log.Show();
                        }
                        else
                        {

                            MessageBox.Show("Login failed. Please check your username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        con.Close();
                        Clear();
                    }
                }
            }
        }
    }
}
