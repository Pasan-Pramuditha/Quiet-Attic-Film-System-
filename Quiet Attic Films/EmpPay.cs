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
    public partial class EmpPay : Form
    {
        int Pay_ID, Payment_Amount;
        string Pay_Method;
        DateTime Date_Time;
        SqlConnection con = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;");

        public EmpPay()
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
            EmployeeForm f15 = new EmployeeForm();
            this.Hide();
            f15.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            EmpCus f21 = new EmpCus();
            this.Hide();
            f21.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            EmpCus f21 = new EmpCus();
            this.Hide();
            f21.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            EmpOder f22 = new EmpOder();
            this.Hide();
            f22.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            EmpOder f22 = new EmpOder();
            this.Hide();
            f22.Show();
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


        //UPDATE
        private void butUpdate_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    LoadElement();
                    con.Open();
                    string update = "update Payment set Payment_Amount = '" + Payment_Amount + "', Pay_Date_Time = '" + Date_Time + "', Pay_Method = '" + Pay_Method + "' where Pay_ID = '" + Pay_ID + "'";
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

        private void label23_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void EmpPay_Load(object sender, EventArgs e)
        {
            LoadGridView();

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
