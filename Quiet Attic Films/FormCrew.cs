using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Quiet_Attic_Films
{
    public partial class FormCrew : Form
    {
        int Crew_ID, Countofcrew, Contact01, Contact02, Workdays;
        SqlConnection con = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;");

        //Insert
        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                LoadElement();
                con.Open();
                string insert = "insert into Crew values ('" + Crew_ID + "','" + Countofcrew + "','" + Contact01 + "','" + Contact02 + "','" + Workdays + "')";
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




        //Update
        private void butUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                LoadElement();
                con.Open();
                string update = "update Crew set Count_Of_Crew = '" + Countofcrew + "',Crew_Contact_No1 = '" + Contact01 + "',Crew_Contact_No2='" + Contact02 + "',Work_Days = '" + Workdays + "' where Crew_ID = '" + Crew_ID + "'";
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated successfully!");
                Clear();
                LoadGridView();
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



        //Delete 
        private void butDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete this?", "Warning message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int CrewID;
                if (!int.TryParse(texID.Text, out CrewID))
                {
                    MessageBox.Show("Please enter a valid Crew ID.");
                    return;
                }

                using (SqlConnection con  = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;"))

                {
                    string deleteQuery = "DELETE FROM Crew WHERE Crew_ID = @CrewID";

                    try
                    {
                        con.Open();

                        using (SqlCommand command = new SqlCommand(deleteQuery, con))
                        {
                            command.Parameters.AddWithValue("@CrewID", CrewID);
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
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            LoadGridView();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            AdminForm f10 = new AdminForm();
            this.Hide();
            f10.Show();
        }


        //Seacher

        private void butSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Crew_ID = int.Parse(texsearch.Text);
                con.Open();
                string search = "select * from Crew where Crew_ID = '" + Crew_ID + "'";
                SqlCommand cmd = new SqlCommand(search, con);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    texCount.Text = read["Count_Of_Crew"].ToString();
                    texContact01.Text = read["Crew_Contact_No1"].ToString();
                    texContact02.Text = read["Crew_Contact_No2"].ToString();
                    texWork.Text = read["Work_Days"].ToString();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid Crew ID.");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
        {
            FormEmp A9 = new FormEmp();
            this.Hide();
            A9.Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            FormEmp A9 = new FormEmp();
            this.Hide();
            A9.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            FormCustomer A9 = new FormCustomer();
            this.Hide();
            A9.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FormCustomer A9 = new FormCustomer();
            this.Hide();
            A9.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            FormOrder A9 = new FormOrder();
            this.Hide();
            A9.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FormOrder A9 = new FormOrder();
            this.Hide();
            A9.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            FormProduction A9 = new FormProduction();
            this.Hide();
            A9.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FormProduction A9 = new FormProduction();
            this.Hide();
            A9.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            FormProperty A9 = new FormProperty();
            this.Hide();
            A9.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FormProperty A9 = new FormProperty();
            this.Hide();
            A9.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            FormLocation A9 = new FormLocation();
            this.Hide();
            A9.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            FormLocation A9 = new FormLocation();
            this.Hide();
            A9.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            FormPayment A9 = new FormPayment();
            this.Hide();
            A9.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            FormPayment A9 = new FormPayment();
            this.Hide();
            A9.Show();
        }

        public FormCrew()
        {
            InitializeComponent();
        }

        //Add Client Button
        private void LoadElement()
        {
            Crew_ID = int.Parse(texID.Text);
            Countofcrew = int.Parse(texCount.Text);
            Contact01 = int.Parse(texContact01.Text);
            Contact02 = int.Parse(texContact02.Text);
            Workdays = int.Parse(texWork.Text);

        }
        private void Clear()
        {
            texID.Clear();
            texCount.Clear();
            texContact01.Clear();
            texContact02.Clear();
            texWork.Clear();
            texsearch.Clear();
            texID.Focus();

        }

        //LoadGridVie
        private void LoadGridView()
        {
            try
            {
                string connectionString = @"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;";
                string query = "SELECT * FROM Crew";

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
    }

}



