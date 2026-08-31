using Quiet_Attic_Films;
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
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            EmpCus f12 = new EmpCus();
            this.Hide();
            f12.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            EmpCus f12 = new EmpCus();
            this.Hide();
            f12.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            EmpCus f12 = new EmpCus();
            this.Hide();
            f12.Show();
        }

        private void panel11_Click(object sender, EventArgs e)
        {
            EmpOder f13 = new EmpOder();
            this.Hide();
            f13.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            EmpOder f13 = new EmpOder();
            this.Hide();
            f13.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            EmpOder f13 = new EmpOder();
            this.Hide();
            f13.Show();
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            EmpPay f14 = new EmpPay();
            this.Hide();
            f14.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            EmpPay f14 = new EmpPay();
            this.Hide();
            f14.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            EmpPay f14 = new EmpPay();
            this.Hide();
            f14.Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Logout", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoginForm f16 = new LoginForm();
                this.Hide();
                f16.Show();
            }
            else
                this.Show();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
