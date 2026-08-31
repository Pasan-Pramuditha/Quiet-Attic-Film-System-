using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;


namespace Quiet_Attic_Films
{
    public partial class FormOrder : Form
    {
        int Order_ID;
        string Order_Name, Order_Type;
        DateTime Date_Time;
        SqlConnection con = new SqlConnection(@"Data Source=PASAN\SQLEXPRESS;Initial Catalog=Quite_Attic_Films_Version_5;Integrated Security=True;TrustServerCertificate=True;");

        public FormOrder()
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
        

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            AdminForm f10 = new AdminForm();
            this.Hide();
            f10.Show();
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


        private void FormOrder_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Clear();
        }


        //Update
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


        //Search
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

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            FormAdmin O = new FormAdmin();
            this.Hide();
            O.Show();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            FormAdmin O = new FormAdmin();
            this.Hide();
            O.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormEmp O = new FormEmp();
            this.Hide();
            O.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FormEmp O = new FormEmp();
            this.Hide();
            O.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FormCrew O = new FormCrew();
            this.Hide();
            O.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            FormCrew O = new FormCrew();
            this.Hide();
            O.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FormCustomer O = new FormCustomer();
            this.Hide();
            O.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            FormCustomer O = new FormCustomer();
            this.Hide();
            O.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FormProduction O = new FormProduction();
            this.Hide();
            O.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            FormProduction O = new FormProduction();
            this.Hide();
            O.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FormProperty O = new FormProperty();
            this.Hide();
            O.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            FormProperty O = new FormProperty();
            this.Hide();
            O.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            FormLocation O = new FormLocation();
            this.Hide();
            O.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            FormLocation O = new FormLocation();
            this.Hide();
            O.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            FormPayment O = new FormPayment();
            this.Hide();
            O.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            FormPayment O = new FormPayment();
            this.Hide();
            O.Show();
        }



        //Insert
        private void butAdd_Click(object sender, EventArgs e)
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
                LoadGridView();
                Clear();
            }
        }





    }
}
