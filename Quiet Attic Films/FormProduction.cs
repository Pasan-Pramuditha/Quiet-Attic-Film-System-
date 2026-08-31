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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Quiet_Attic_Films
{
    public partial class FormProduction : Form
    {
        int Production_ID;
        string Production_Name, Productionst_Type, Duration;
        SqlConnection con = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;;");

        public FormProduction()
        {
            InitializeComponent();
            LoadGridView();
        }

        //Buttons
        private void LoadElement()
        {
            Production_ID = int.Parse(texPID.Text);
            Duration  = texDuration.Text;
            Production_Name = texPName.Text;
            Productionst_Type = comPType.Text;
            
            

        }

        //Clear
        private void Clear()
        {
            texPID.Clear();
            texDuration.Clear();
            texPName.ResetText();
            comPType.ResetText();
            texsearch.ResetText();
            texPID.Focus();

        }

        //LoadGridView
        private void LoadGridView()
        {
            try
            {
                string connectionString = @"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;";
                string query = "SELECT * FROM Production";

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
            FormAdmin P = new FormAdmin();
            this.Hide();
            P.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            FormPayment P = new FormPayment();
            this.Hide();
            P.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            FormPayment P = new FormPayment();
            this.Hide();
            P.Show();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            FormAdmin P = new FormAdmin();
            this.Hide();
            P.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormEmp P = new FormEmp();
            this.Hide();
            P.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FormEmp P = new FormEmp();
            this.Hide();
            P.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FormCrew P = new FormCrew();
            this.Hide();
            P.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            FormCrew P = new FormCrew();
            this.Hide();
            P.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FormCustomer P = new FormCustomer();
            this.Hide();
            P.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            FormCustomer P = new FormCustomer();
            this.Hide();
            P.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FormOrder P = new FormOrder();
            this.Hide();
            P.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            FormOrder P = new FormOrder();
            this.Hide();
            P.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FormProperty P = new FormProperty();
            this.Hide();
            P.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            FormProperty P = new FormProperty();
            this.Hide();
            P.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            FormLocation P = new FormLocation();
            this.Hide();
            P.Show();
        }
        // UPDATE

        private void butUpdate_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    LoadElement();
                    con.Open();
                    string update = "update Production set Production_Name = '" + Production_Name + "', Duration = '" + Duration + "', Production_Type = '" + Productionst_Type + "' where Production_ID = '" + Production_ID + "'";
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
                int Production_ID;
                if (!int.TryParse(texPID.Text, out Production_ID))
                {
                    MessageBox.Show("Please enter a valid Production ID.");
                    return;
                }

                using (SqlConnection con = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;"))

                {
                    string deleteQuery = "DELETE FROM Production WHERE Production_ID = @ProductionID";

                    try
                    {
                        con.Open();

                        using (SqlCommand command = new SqlCommand(deleteQuery, con))
                        {
                            command.Parameters.AddWithValue("@ProductionID", Production_ID);
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
            {
                try
                {
                    Production_ID = int.Parse(texsearch.Text);
                    con.Open();
                    string search = "select * from Production where Production_ID = '" + Production_ID + "'";
                    SqlCommand cmd = new SqlCommand(search, con);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        texDuration.Text = read["Duration"].ToString();
                        texPName.Text = read["Production_Name"].ToString();
                        comPType.Text = read["Production_Type"].ToString();

                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a valid Production ID.");
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

        private void label10_Click(object sender, EventArgs e)
        {
            FormLocation P = new FormLocation();
            this.Hide();
            P.Show();
        }

        //INSERT
        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                LoadElement();
                con.Open();
                string insert = "INSERT INTO Production (Production_ID, Production_Name, Duration, Production_Type) VALUES ('" + Production_ID + "', '" + Production_Name + "', '" + Duration + "', '" + Productionst_Type + "')";
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
    }
}
