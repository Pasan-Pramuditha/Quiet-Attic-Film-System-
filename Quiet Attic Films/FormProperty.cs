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
    public partial class FormProperty : Form
    { 
        int Property_ID;
        string Property_Name,Property_Type;
        SqlConnection con = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;");

        public FormProperty()
        {
            InitializeComponent();
            
        }


        private void LoadElement()
        {
            Property_ID = int.Parse(texProID.Text);
            Property_Name = comProType.Text;
            Property_Type = texProName.Text;
        }
        private void Clear()
        {
            texProID.Clear();
            comProType.ResetText();
            texProName.ResetText();
            texsearch.Clear();
            texProID.Focus();
        }


        //LoadGridVie
        private void LoadGridView()
        {
            try
            {
                string connectionString = @"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;";
                string query = "SELECT * FROM Property";

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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FormProduction P = new FormProduction();
            this.Hide();
            P.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            FormProduction P = new FormProduction();
            this.Hide();
            P.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            FormLocation P = new FormLocation();
            this.Hide();
            P.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            FormLocation P = new FormLocation();
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

        private void label12_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void FormProperty_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }

        //UPDATE
        private void butUpdate_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    LoadElement();
                    con.Open();
                    string update = "update Property set Property_Name = '" + Property_Name + "', Property_Type = '" + Property_Type + "' where Property_ID = '" + Property_ID + "'";
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
                int PropertyID;
                if (!int.TryParse(texProID.Text, out PropertyID))
                {
                    MessageBox.Show("Please enter a valid Property ID.");
                    return;
                }

                using (SqlConnection con = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;"))

                {
                    string deleteQuery = "DELETE FROM Property WHERE Property_ID = @PropertyID";

                    try
                    {
                        con.Open();

                        using (SqlCommand command = new SqlCommand(deleteQuery, con))
                        {
                            command.Parameters.AddWithValue("@PropertyID", PropertyID);
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
                    Property_ID = int.Parse(texsearch.Text);
                    con.Open();
                    string search = "select * from Property where Property_ID = '" + Property_ID + "'";
                    SqlCommand cmd = new SqlCommand(search, con);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        texProName.Text = read["Property_Name"].ToString();
                        comProType.Text = read["Property_Type"].ToString();
                        texProID.Text = read["Property_ID"].ToString();
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a valid Payment ID.");
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
        }

        //INSERT
        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                LoadElement();
                con.Open();
                string insert = "INSERT INTO Property (Property_ID, Property_Name, Property_Type) VALUES ('" + Property_ID + "', '" + Property_Name + "', '" + Property_Type +  "')";
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
