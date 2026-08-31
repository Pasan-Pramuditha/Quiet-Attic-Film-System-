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
    public partial class SelectAdEmp : Form
    {
        public SelectAdEmp()
        {
            InitializeComponent();
        }

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AdminLogin f1 = new AdminLogin();
            this.Hide();
            f1.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LoginForm f2 = new LoginForm();
            this.Hide();
            f2.Show();

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SelectAdEmp_Load(object sender, EventArgs e)
        {

        }
    }
}
