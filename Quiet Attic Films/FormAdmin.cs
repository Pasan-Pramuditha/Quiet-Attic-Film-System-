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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Runtime.Remoting.Lifetime;

namespace Quiet_Attic_Films
{
    public partial class FormAdmin : Form
    {
        int Admin_ID, Contact_No1, Contact_No2;
        string First_Name, Last_Name, UserName, Password;
        DateTime DOB;
        SqlConnection con = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True");


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            LoadGridView();
        }


        //UPDATE
        private void butUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                LoadElement();
                con.Open();
                string update = "update Admin set First_Name = '" + First_Name + "', Last_Name = '" + Last_Name + "', DOB = '" + DOB + "', Admin_Contact_No1 = '" + Contact_No1 + "', Admin_Contact_No2 = '" + Contact_No1 + "', User_Name = '" + UserName + "', Password = '" + Password + "' where Admin_ID = '" + Admin_ID + "'";
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated successfully!");
                LoadGridView();
                Clear();
            }
            
            catch (Exception )
            {
                MessageBox.Show("No data entered try agen");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }


        //DELETE
        private void butDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete this?", "Warning message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int AdminID;
                if (!int.TryParse(texAdminID.Text, out AdminID))
                {
                    MessageBox.Show("Please enter a valid Admin ID.");
                    return;
                }

                using (SqlConnection con = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True"))

                {
                    string deleteQuery = "DELETE FROM Admin WHERE Admin_ID = @AdminID";

                    try
                    {
                        con.Open();

                        using (SqlCommand command = new SqlCommand(deleteQuery, con))
                        {
                            command.Parameters.AddWithValue("@AdminID", AdminID);
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Deleted successfully!");
                            }
                            else
                            {
                                MessageBox.Show("No records found for deletion.");
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    LoadGridView();
                    Clear();
                }
            }
        }


        //SEARCH
        private void butSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Admin_ID = int.Parse(texSearch.Text);
                con.Open();
                string search = "select * from Admin where Admin_ID = '" + Admin_ID + "'";
                SqlCommand cmd = new SqlCommand(search, con);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    texFname.Text = read["First_Name"].ToString();
                    texLname.Text = read["Last_Name"].ToString();
                    dateTimeDOB.Text = read["DOB"].ToString();
                    textContact_No1.Text = read["Admin_Contact_No1"].ToString();
                    textContact_No2.Text = read["Admin_Contact_No2"].ToString();
                    texUsername.Text = read["User_Name"].ToString();
                    texPassword.Text = read["Password"].ToString();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid Admin ID.");
            }
            
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }


        private void label23_Click(object sender, EventArgs e)
        {
            Clear();
        }

        

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            AdminForm f10 = new AdminForm();
            this.Hide();
            f10.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FormEmp A1 = new FormEmp();
            this.Hide();
            A1.Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            FormEmp A1 = new FormEmp();
            this.Hide();
            A1.Show();
        }

        private void label24_Click(object sender, EventArgs e)
        {
            FormCrew A2 = new FormCrew();
            this.Hide();
            A2.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FormCrew A2 = new FormCrew();
            this.Hide();
            A2.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            FormCustomer A3 = new FormCustomer();
            this.Hide();
            A3.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FormCustomer A3 = new FormCustomer();
            this.Hide();
            A3.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            FormOrder A4 = new FormOrder();
            this.Hide();
            A4.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FormOrder A4 = new FormOrder();
            this.Hide();
            A4.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            FormProduction A5 = new FormProduction();
            this.Hide();
            A5.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FormProduction A5 = new FormProduction();
            this.Hide();
            A5.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            FormProperty A6 = new FormProperty();
            this.Hide();
            A6.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FormProperty A6 = new FormProperty();
            this.Hide();
            A6.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            FormLocation A7 = new FormLocation();
            this.Hide();
            A7.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            FormLocation A7 = new FormLocation();
            this.Hide();
            A7.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            FormPayment A8 = new FormPayment();
            this.Hide();
            A8.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            FormPayment A8 = new FormPayment();
            this.Hide();
            A8.Show();
        }

        public FormAdmin()
        {
            InitializeComponent();
        }

        //Buttons
        private void LoadElement()
        {
            Admin_ID = int.Parse(texAdminID.Text);
            First_Name = texFname.Text;
            Last_Name = texLname.Text;
            DOB = dateTimeDOB.Value.Date;
            Contact_No1 = int.Parse(textContact_No1.Text);
            Contact_No2 = int.Parse(textContact_No2.Text);
            UserName = texUsername.Text;
            Password = texPassword.Text;

        }

        //Clear
        private void Clear()
        {
            texAdminID.Clear();
            texFname.Clear();
            texLname.Clear();
            texPassword.Clear();
            dateTimeDOB.ResetText();
            texUsername.Clear();
            texPassword.ResetText();
            textContact_No1.Clear();
            textContact_No2.Clear();
            texSearch.Clear();
            texAdminID.Focus();

        }

        //LoadGridView
        private void LoadGridView()
        {
            try
            {
                string connectionString = @"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True";
                string query = "SELECT * FROM Admin";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        //INSERT
        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                LoadElement();
                con.Open();
                string insert = "insert into Admin (Admin_ID, First_Name, Last_name, DOB, Admin_Contact_No1, Admin_Contact_No2, User_Name, Password) values ('" + Admin_ID + "','" + First_Name + "','" + Last_Name + "','" + DOB + "','" + Contact_No1 + "','" + Contact_No2 + "','" + UserName + "','" + Password + "')";
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved successfully!");
                Clear();
            }
            catch (SqlException )
            {
                MessageBox.Show("Alredy have Enter Id please try agen");
            }
            catch (Exception )
            {
                MessageBox.Show("No data entered try agen");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }


    }
}
