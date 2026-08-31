using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace Quiet_Attic_Films
{
    public partial class FormEmp : Form
    {

        int Employee_ID, Salary, Contact_No1, Contact_No2;
        string First_Name, Last_name, Address, Job_Role, User_Name, Password;
        DateTime DOB;
        SqlConnection con = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;");


        //Delete
        private void butDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete this?", "Warning message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int EmployeeID;
                if (!int.TryParse(texEmpID.Text, out EmployeeID))
                {
                    MessageBox.Show("Please enter a valid Employee ID.");
                    return;
                }

                using (SqlConnection con = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;"))

                {
                    string deleteQuery = "DELETE FROM Employee WHERE Employee_ID = @EmployeeID";

                    try
                    {
                        con.Open();

                        using (SqlCommand command = new SqlCommand(deleteQuery, con))
                        {
                            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
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

        private void label23_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            LoadGridView();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            FormCrew f1 = new FormCrew();
            this.Hide();
            f1.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            FormCustomer f2 = new FormCustomer();
            this.Hide();
            f2.Show();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            FormAdmin A9 = new FormAdmin();
            this.Hide();
            A9.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormAdmin A9 = new FormAdmin();
            this.Hide();
            A9.Show();
        }

        private void label24_Click(object sender, EventArgs e)
        {
            FormCrew A10 = new FormCrew();
            this.Hide();
            A10.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FormCrew A10 = new FormCrew();
            this.Hide();
            A10.Show();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            FormCustomer A11 = new FormCustomer();
            this.Hide();
            A11.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FormCustomer A11 = new FormCustomer();
            this.Hide();
            A11.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            FormOrder A12 = new FormOrder();
            this.Hide();
            A12.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FormOrder A12 = new FormOrder();
            this.Hide();
            A12.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            FormProduction A13 = new FormProduction();
            this.Hide();
            A13.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FormProduction A13 = new FormProduction();
            this.Hide();
            A13.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            FormProperty A14 = new FormProperty();
            this.Hide();
            A14.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FormProperty A14 = new FormProperty();
            this.Hide();
            A14.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            FormLocation A15 = new FormLocation();
            this.Hide();
            A15.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            FormLocation A15 = new FormLocation();
            this.Hide();
            A15.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            FormPayment A16 = new FormPayment();
            this.Hide();
            A16.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            FormPayment A16 = new FormPayment();
            this.Hide();
            A16.Show();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void FormEmp_Load(object sender, EventArgs e)
        {

        }

        //Search
        private void butSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Employee_ID = int.Parse(texSearch.Text);
                con.Open();
                string search = "select * from Employee where Employee_ID = '" + Employee_ID + "'";
                SqlCommand cmd = new SqlCommand(search, con);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    texFname.Text = read["First_Name"].ToString();
                    texLname.Text = read["Last_Name"].ToString();
                    texSalary.Text = read["Salary"].ToString();
                    dateTimeDOB.Text = read["DOB"].ToString();
                    texAddress.Text = read["Employee_Address"].ToString();
                    textContact_No1.Text = read["Employee_Contact_No1"].ToString();
                    textContact_No2.Text = read["Employee_Contact_No2"].ToString();
                    combojob.Text = read["Job_Role"].ToString();
                    texUsername.Text = read["User_Name"].ToString();
                    texPassword.Text = read["Password"].ToString();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid Employee ID.");
            }
            
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }




        private void pictureBox11_Click(object sender, EventArgs e)
        {
            AdminForm f10 = new AdminForm();
            this.Hide();
            f10.Show();

        }
        //Update
        private void butUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                LoadElement();
                con.Open();
                string update = "update Employee set First_Name = '" + First_Name + "', Last_Name = '" + Last_name + "', Salary = '" + Salary + "', DOB = '" + DOB + "', Employee_Address = '" + Address + "', Employee_Contact_No1 = '" + Contact_No1 + "', Employee_Contact_No2 = '" + Contact_No1 + "', Job_Role = '" + Job_Role + "', User_Name = '" + User_Name + "', Password = '" + Password + "' where Employee_ID = '" + Employee_ID + "'";
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




        //Insert
        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                LoadElement();
                con.Open();
                string insert = "INSERT INTO Employee (Employee_ID, First_Name, Last_name, Salary, DOB, Employee_Address, Employee_Contact_No1, Employee_Contact_No2, Job_Role, User_Name, Password) " +
                                "VALUES ('" + Employee_ID + "', '" + First_Name + "', '" + Last_name + "', '" + Salary + "', '" + DOB + "', '" + Address + "', '" + Contact_No1 + "', '" + Contact_No2 + "', '" + Job_Role + "', '" + User_Name + "', '" + Password + "')";
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved successfully!");
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
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
                Clear();
            }
        }


        public FormEmp()
        {
            InitializeComponent();
        }


        //LoadGridView
        private void LoadGridView()
        {
            try
            {
                string connectionString = @"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;";
                string query = "SELECT * FROM Employee";

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

        //Buttons
        private void LoadElement()
        {
            Employee_ID = int.Parse(texEmpID.Text);
            First_Name = texFname.Text;
            Last_name = texLname.Text;
            Salary = int.Parse(texSalary.Text);
            DOB = dateTimeDOB.Value.Date;
            Address = texAddress.Text;
            Contact_No1 = int.Parse(textContact_No1.Text);
            Contact_No2 = int.Parse(textContact_No2.Text);
            Job_Role = combojob.Text;
            User_Name = texUsername.Text;
            Password = texPassword.Text;
        }

        //Clear
        private void Clear()
        {
            texEmpID.Clear();
            texFname.Clear();
            texLname.Clear();
            texSalary.Clear();
            dateTimeDOB.ResetText();
            texAddress.Clear();
            textContact_No1.Clear();
            textContact_No2.Clear();
            combojob.ResetText();
            texUsername.Clear();
            texPassword.Clear();
            texSearch.Clear();
            texEmpID.Focus();

        }



    }
}

