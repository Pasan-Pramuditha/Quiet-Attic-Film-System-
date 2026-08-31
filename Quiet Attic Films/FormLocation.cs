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
    public partial class FormLocation : Form
    {

        int Location_ID, Per_Pay_Day;
        string Location_Name, Location_Address;
       
        SqlConnection con = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;");

        public FormLocation()
        {
            InitializeComponent();
            LoadGridView();
        }

        private void LoadElement()
        {
            Location_ID = int.Parse(txtLID.Text);
            Per_Pay_Day = int.Parse(txtLPer.Text);
            Location_Name = txtLName.Text;
            Location_Address = txtLAdd.Text;

        }
        private void Clear()
        {
            txtLID.Clear();
            txtLName.Clear();
            txtLAdd.ResetText();
            txtLPer.ResetText();
            texsearch.Clear();
            txtLID.Focus();
        }

        //LoadGridVie
        private void LoadGridView()
        {
            try
            {
                string connectionString = @"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;";
                string query = "SELECT * FROM Location";

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

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            AdminForm f10 = new AdminForm();
            this.Hide();
            f10.Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            FormAdmin L = new FormAdmin();
            this.Hide();
            L.Show();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            FormAdmin L = new FormAdmin();
            this.Hide();
            L.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormEmp L = new FormEmp();
            this.Hide();
            L.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FormEmp L = new FormEmp();
            this.Hide();
            L.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FormCrew L = new FormCrew();
            this.Hide();
            L.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            FormCrew L = new FormCrew();
            this.Hide();
            L.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FormCustomer L = new FormCustomer();
            this.Hide();
            L.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            FormCustomer L = new FormCustomer();
            this.Hide();
            L.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FormOrder L = new FormOrder();
            this.Hide();
            L.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            FormOrder L = new FormOrder();
            this.Hide();
            L.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FormProduction L = new FormProduction();
            this.Hide();
            L.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            FormProduction L = new FormProduction();
            this.Hide();
            L.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FormProperty L = new FormProperty();
            this.Hide();
            L.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            FormProperty L = new FormProperty();
            this.Hide();
            L.Show();
        }


        //INSERT
        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                LoadElement();
                con.Open();
                string insert = "INSERT INTO Location (Location_ID, Location_Name, Location_Address, Per_Pay_Day) VALUES ('" + Location_ID + "', '" + Location_Name + "', '" + Location_Address + "', '" + Per_Pay_Day + "')";
                SqlCommand cmd = new SqlCommand(insert, con);
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

                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                LoadGridView();
                Clear();
            }
        }

        //UPDATE
        private void butUpdate_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    LoadElement();
                    con.Open();
                    string update = "update Location set Location_Name = '" + Location_Name + "', Location_Address = '" + Location_Address + "', Per_Pay_Day = '" + Per_Pay_Day + "' where Location_ID = '" + Location_ID + "'";
                    SqlCommand cmd = new SqlCommand(update, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated successfully!");
                    LoadGridView();
                    Clear();
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
        }

        //DELETE
        private void butDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete this?", "Warning message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int LocationID;
                if (!int.TryParse(txtLID.Text, out LocationID))
                {
                    MessageBox.Show("Please enter a valid Location ID.");
                    return;
                }

                using (SqlConnection con = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;"))

                {
                    string deleteQuery = "DELETE FROM Location WHERE Location_ID = @LocationID";

                    try
                    {
                        con.Open();

                        using (SqlCommand command = new SqlCommand(deleteQuery, con))
                        {
                            command.Parameters.AddWithValue("@LocationID", LocationID);
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

        //Search
        private void butSearch_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    Location_ID = int.Parse(texsearch.Text);
                    con.Open();
                    string search = "select * from Location where Location_ID = '" + Location_ID + "'";
                    SqlCommand cmd = new SqlCommand(search, con);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        txtLName.Text = read["Location_Name"].ToString();
                        txtLAdd.Text = read["Location_Address"].ToString();
                        txtLPer.Text = read["Per_Pay_Day"].ToString();
                        txtLID.Text = read["Location_ID"].ToString();

                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a valid Location ID.");
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            FormPayment L = new FormPayment();
            this.Hide();
            L.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            FormPayment L = new FormPayment();
            this.Hide();
            L.Show();
        }
    }
}

