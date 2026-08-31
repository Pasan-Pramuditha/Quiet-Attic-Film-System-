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
using System.Windows.Forms.VisualStyles;

namespace Quiet_Attic_Films
{
    public partial class EmpOder : Form
    {
        int Order_ID;
        string Order_Name, Order_Type;
        DateTime Date_Time;
        SqlConnection con = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;");

        public EmpOder()
        {
            InitializeComponent();
        }

        private void LoadElement()
        {
            Order_ID = int.Parse(texOrID.Text);
            Order_Name = texName.Text;
            Order_Type = comboType.Text;
            Date_Time = dateTimeTime.Value;

        }

        private void Clear()
        {
            texOrID.Clear();
            texName.Clear();
            dateTimeTime.ResetText();
            comboType.ResetText();
            texSearch.Clear();
            texOrID.Focus();

        }

        //LoadGridView
        private void LoadGridView()
        {
            string connectionString = @"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;";
            string query = "SELECT * FROM [Order]";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
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
            EmpCus f19 = new EmpCus();
            this.Hide();
            f19.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            EmpCus f19 = new EmpCus();
            this.Hide();
            f19.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            EmpPay f20 = new EmpPay();
            this.Hide();
            f20.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            EmpPay f20 = new EmpPay();
            this.Hide();
            f20.Show();
        }

        private void EmpOder_Load(object sender, EventArgs e)
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
                string update = "update [Order] set Order_Name = '" + Order_Name + "', Date_Time = '" + Date_Time + "', Order_Type = '" + Order_Type + "' where Order_ID  = '" + Order_ID + "'";
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


        //DELETE
        private void butDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete this?", "Warning message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int OrderID;
                if (!int.TryParse(texOrID.Text, out OrderID))
                {
                    MessageBox.Show("Please enter a valid Order ID.");
                    return;
                }

                using (SqlConnection con = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;"))
                {
                    string deleteQuery = "DELETE FROM [Order] WHERE Order_ID = @OrderID";

                    try
                    {
                        con.Open();
                        using (SqlCommand command = new SqlCommand(deleteQuery, con))
                        {
                            command.Parameters.AddWithValue("@OrderID", OrderID);
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
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                            con.Close();
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
                Order_ID = int.Parse(texSearch.Text);
                con.Open();
                string search = "select * from [Order] where Order_ID = '" + Order_ID + "'";
                SqlCommand cmd = new SqlCommand(search, con);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    texName.Text = read["Order_Name"].ToString();
                    dateTimeTime.Text = read["Date_Time"].ToString();
                    comboType.Text = read["Order_Type"].ToString();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid Order ID.");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }


     

        //INSERT

        private void button1_Click(object sender, EventArgs e)
        {
            LoadElement();
            try
            {
                con.Open();
                string insert = "INSERT INTO [Order] (Order_ID, Order_Name, Date_Time, Order_Type) VALUES ('" + Order_ID + "', '" + Order_Name + "', '" + Date_Time + "', '" + Order_Type + "')";
                using (SqlCommand cmd = new SqlCommand(insert, con))
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Saved successfully!");
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
                Clear();
                LoadGridView();
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Clear();
        }

        
    }
}
