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

namespace Quiet_Attic_Films
{
    public partial class AdminLogin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True");


        public AdminLogin()
        {
            InitializeComponent();
        }

        private void Clear()
        {

            texPassword.Clear();
            texUsername.Clear();
            texUsername.Focus();

        }

        private void butLogin_Click(object sender, EventArgs e)
        {
            string username = texUsername.Text;
            string password = texPassword.Text;

            string query = "SELECT COUNT(*) FROM Admin WHERE User_Name = @username AND Password = @password";

            
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int result = (int)cmd.ExecuteScalar();

                    if (result > 0)
                    {
                        MessageBox.Show("Login successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AdminForm log = new AdminForm();
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

        private void texPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            SelectAdEmp log = new SelectAdEmp();
            this.Hide();
            log.Show();
        }
    }
}
