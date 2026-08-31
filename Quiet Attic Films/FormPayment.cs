using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Quiet_Attic_Films
{
    public partial class FormPayment : Form
    {

        int Pay_ID, Payment_Amount;
        string Pay_Method;
        DateTime Date_Time;
        SqlConnection con = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;");

        public FormPayment()
        {
            InitializeComponent();
        }

        private void LoadElement()
        {
            Pay_ID = int.Parse(texpayID.Text);
            Payment_Amount = int.Parse(texammount.Text);
            Date_Time = dateTimeTime.Value;
            Pay_Method = compayM.Text;

        }
        private void Clear()
        {
            texpayID.Clear();
            texammount.Clear();
            dateTimeTime.ResetText();
            compayM.ResetText();
            texsearch.Clear();
            texpayID.Focus();
        }

        //LoadGridVie
        private void LoadGridView()
        {
            try
            {
                string connectionString = @"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;";
                string query = "SELECT * FROM Payment";

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


        //SEARCH
        private void butSearch_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    Pay_ID = int.Parse(texsearch.Text);
                    con.Open();
                    string search = "select * from Payment where Pay_ID = '" + Pay_ID + "'";
                    SqlCommand cmd = new SqlCommand(search, con);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        texammount.Text = read["Payment_Amount"].ToString();
                        dateTimeTime.Text = read["Pay_Date_Time"].ToString();
                        compayM.Text = read["Pay_Method"].ToString();
                        
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


        //DELETE
        private void butDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete this?", "Warning message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int PayID;
                if (!int.TryParse(texpayID.Text, out PayID))
                {
                    MessageBox.Show("Please enter a valid Payment ID.");
                    return;
                }

                using (SqlConnection con = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;"))

                {
                    string deleteQuery = "DELETE FROM Payment WHERE Pay_ID = @PayID";

                    try
                    {
                        con.Open();

                        using (SqlCommand command = new SqlCommand(deleteQuery, con))
                        {
                            command.Parameters.AddWithValue("@PayID", PayID);
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

        private void FormPayment_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Clear();
        }


        //UPDATE    
        private void butUpdate_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    LoadElement();
                    con.Open();
                    string update = "update Payment set Payment_Amount = '" + Payment_Amount + "', Pay_Date_Time = '" + Date_Time + "', Pay_Method = '" + Pay_Method +  "' where Pay_ID = '" + Pay_ID + "'";
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

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            FormAdmin Pay = new FormAdmin();
            this.Hide();
            Pay.Show();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            FormAdmin Pay = new FormAdmin();
            this.Hide();
            Pay.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormEmp Pay = new FormEmp();
            this.Hide();
            Pay.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FormEmp Pay = new FormEmp();
            this.Hide();
            Pay.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FormCrew Pay = new FormCrew();
            this.Hide();
            Pay.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            FormCrew Pay = new FormCrew();
            this.Hide();
            Pay.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FormCustomer Pay = new FormCustomer();
            this.Hide();
            Pay.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            FormCustomer Pay = new FormCustomer();
            this.Hide();
            Pay.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FormOrder Pay = new FormOrder();
            this.Hide();
            Pay.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            FormOrder Pay = new FormOrder();
            this.Hide();
            Pay.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FormProduction Pay = new FormProduction();
            this.Hide();
            Pay.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            FormProduction Pay = new FormProduction();
            this.Hide();
            Pay.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FormProperty Pay = new FormProperty();
            this.Hide();
            Pay.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            FormProperty Pay = new FormProperty();
            this.Hide();
            Pay.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            FormLocation Pay = new FormLocation();
            this.Hide();
            Pay.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            FormLocation Pay = new FormLocation();
            this.Hide();
            Pay.Show();
        }

        //INSERT
        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                LoadElement();
                con.Open();
                string insert = "INSERT INTO Payment (Pay_ID, Payment_Amount, Pay_Date_Time, Pay_Method) VALUES ('" + Pay_ID + "', '" + Payment_Amount + "', '" + Date_Time + "', '" + Pay_Method + "')";
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
                {
                    con.Close();
                }
                LoadGridView();
                Clear();
            }
        }


    }
}
    

  

