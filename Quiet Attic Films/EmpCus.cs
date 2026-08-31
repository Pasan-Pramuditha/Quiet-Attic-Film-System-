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
    public partial class EmpCus : Form
    {
        int Customer_ID, Contact_No1, Contact_No2;
        string First_Name, Last_Name, Address, Email, Oder_detaits;
        SqlConnection con = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;");


        //Insert
        private void butAdd_Click(object sender, EventArgs e)
        {
            LoadElement();

            try
            {
                con.Open();
                string insert = "INSERT INTO Customer VALUES (@CustomerID, @FirstName, @LastName, @OrderDetails, @Address, @Email, @ContactNo1, @ContactNo2)";

                SqlCommand cmd = new SqlCommand(insert, con);

                cmd.Parameters.AddWithValue("@CustomerID", Customer_ID);
                cmd.Parameters.AddWithValue("@FirstName", First_Name);
                cmd.Parameters.AddWithValue("@LastName", Last_Name);
                cmd.Parameters.AddWithValue("@OrderDetails", Oder_detaits);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@ContactNo1", Contact_No1);
                cmd.Parameters.AddWithValue("@ContactNo2", Contact_No2);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved successfully!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Alredy have Enter Id please try agen");
            }
            catch (Exception)
            {
                MessageBox.Show("No data entered try agen");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            LoadGridView();
            Clear();
        }

        //Search
        private void butSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Customer_ID = int.Parse(texsearch.Text);
                con.Open();
                string search = "select * from Customer where Customer_ID = '" + Customer_ID + "'";
                SqlCommand cmd = new SqlCommand(search, con);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    texFname.Text = read["F_Name"].ToString();
                    texLname.Text = read["L_Name"].ToString();
                    texOrderd.Text = read["Oder_details"].ToString();
                    texAddress.Text = read["Customer_Address"].ToString();
                    texEmail.Text = read["Customer_Email"].ToString();
                    textContact_No1.Text = read["Custome_Contact_No1"].ToString();
                    textContact_No2.Text = read["Custome_Contact_No2"].ToString();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Alredy have Enter Id please try agen");
            }
            catch (Exception)
            {
                MessageBox.Show("No data entered try agen");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }


        //Delete
        private void butDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete this?", "Warning message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int customerID;
                if (!int.TryParse(Cus_ID.Text, out customerID))
                {
                    MessageBox.Show("Please enter a valid  Customer ID.");
                    return;
                }

                using (SqlConnection con = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;"))

                {
                    string deleteQuery = "DELETE FROM Customer WHERE Customer_ID = @CustomerID";

                    try
                    {
                        con.Open();

                        using (SqlCommand command = new SqlCommand(deleteQuery, con))
                        {
                            command.Parameters.AddWithValue("@CustomerID", customerID);
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


        //Update
        private void butUpdate_Click(object sender, EventArgs e)

        {
            try
            {
                LoadElement();
                con.Open();
                string update = "UPDATE Customer SET F_Name = '" + First_Name + "', L_Name = '" + Last_Name + "', Oder_details = '" + Oder_detaits + "', Customer_Address = '" + Address + "', Customer_Email = '" + Email + "', Custome_Contact_No1 = '" + Contact_No1 + "', Custome_Contact_No2 = '" + Contact_No2 + "' WHERE Customer_ID = '" + Customer_ID + "'";
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated successfully!");
                con.Close();
                LoadGridView();
                Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("No data entered try agen");
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            EmployeeForm f15 = new EmployeeForm();
            this.Hide();
            f15.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            EmpOder f17 = new EmpOder();
            this.Hide();
            f17.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            EmpOder f17 = new EmpOder();
            this.Hide();
            f17.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            EmpPay f18 = new EmpPay();
            this.Hide();
            f18.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            EmpPay f18 = new EmpPay();
            this.Hide();
            f18.Show();
        }

       
        public EmpCus()
        {
            InitializeComponent();
        }

        //Button
        private void LoadElement()
        {
            Customer_ID = int.Parse(Cus_ID.Text);
            First_Name = texFname.Text;
            Last_Name = texLname.Text;
            Address = texAddress.Text;
            Contact_No1 = int.Parse(textContact_No1.Text);
            Contact_No2 = int.Parse(textContact_No2.Text);
            Email = texEmail.Text;
            Oder_detaits = texOrderd.Text;
        }
        //Clear
        private void Clear()
        {
            Cus_ID.Clear();
            texFname.Clear();
            texLname.Clear();
            texAddress.Clear();
            textContact_No1.Clear();
            textContact_No2.Clear();
            texEmail.Clear();
            texOrderd.Clear();
            texsearch.Clear();
            Cus_ID.Focus();

        }

        // LoadGridView
        private void LoadGridView()
        {
            try
            {
                string connectionString = @"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;";
                string query = "SELECT * FROM Customer";

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

        private void EmpCus_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }
    }
}
