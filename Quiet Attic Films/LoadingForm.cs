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
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }
        int startpoint = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            label2.Text = startpoint.ToString() + " %";
            Loding.Value = startpoint;
            if (Loding.Value == 100)
            {
                Loding.Value = 0;
                timer1.Stop();
                SelectAdEmp log = new SelectAdEmp();
                this.Hide();
                log.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            
        }
    }
}
