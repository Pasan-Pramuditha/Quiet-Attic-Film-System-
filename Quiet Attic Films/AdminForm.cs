using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiet_Attic_Films
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void panel10_Click(object sender, EventArgs e)
        {
            FormAdmin F2 = new FormAdmin();
            this.Hide();
            F2.Show();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormAdmin F2 = new FormAdmin();
            this.Hide();
            F2.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FormAdmin F2 = new FormAdmin();
            this.Hide();
            F2.Show();

        }

        private void panel12_Click(object sender, EventArgs e)
        {
            FormCrew f3 = new FormCrew();
            this.Hide();
            f3.Show();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FormCrew f3 = new FormCrew();
            this.Hide();
            f3.Show();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            FormCrew f3 = new FormCrew();
            this.Hide();
            f3.Show();

        }

        private void panel13_Click(object sender, EventArgs e)
        {
            FormCustomer f4 = new FormCustomer();
            this.Hide();
            f4.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FormCustomer f4 = new FormCustomer();
            this.Hide();
            f4.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            FormCustomer f4 = new FormCustomer();
            this.Hide();
            f4.Show();
        }

        private void panel16_Click(object sender, EventArgs e)
        {
            FormOrder f5 = new FormOrder();
            this.Hide();
            f5.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FormOrder f5 = new FormOrder();
            this.Hide();
            f5.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            FormOrder f5 = new FormOrder();
            this.Hide();
            f5.Show();
        }

        private void panel14_Click(object sender, EventArgs e)
        {
            FormProduction f6 = new FormProduction();
            this.Hide();
            f6.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FormProduction f6 = new FormProduction();
            this.Hide();
            f6.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            FormProduction f6 = new FormProduction();
            this.Hide();
            f6.Show();
        }

        private void panel18_Click(object sender, EventArgs e)
        {
            FormProperty f7 = new FormProperty();
            this.Hide();
            f7.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            FormProperty f7 = new FormProperty();
            this.Hide();
            f7.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            FormProperty f7 = new FormProperty();
            this.Hide();
            f7.Show();
        }

        private void panel20_Click(object sender, EventArgs e)
        {
            FormLocation f8 = new FormLocation();
            this.Hide();
            f8.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            FormLocation f8 = new FormLocation();
            this.Hide();
            f8.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            FormLocation f8 = new FormLocation();
            this.Hide();
            f8.Show();
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            FormPayment f9 = new FormPayment();
            this.Hide();
            f9.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            FormPayment f9 = new FormPayment();
            this.Hide();
            f9.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            FormPayment f9 = new FormPayment();
            this.Hide();
            f9.Show();
        }

        

        private void pictureBox(object sender, EventArgs e)
        {
            FormEmp F9 = new FormEmp();
            this.Hide();
            F9.Show();
        }

        private void label_0(object sender, EventArgs e)
        {
            FormEmp F9 = new FormEmp();
            this.Hide();
            F9.Show();
        }

        private void panel(object sender, EventArgs e)
        {
            FormEmp F9 = new FormEmp();
            this.Hide();
            F9.Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Logout", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AdminLogin login_form = new AdminLogin();
                login_form.Show();
                this.Hide();
            }
            else
                this.Show();

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }
    }
    
}
