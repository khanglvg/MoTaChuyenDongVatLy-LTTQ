using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LTTQ
{
    public partial class BeginForm
    {
        public string temp;
        public BeginForm()
        {
            InitializeComponent();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            temp = metroTextBox1.Text;
            HeloForm hlf = new HeloForm();
            hlf.temp1 = temp;
            hlf.Show();
            this.Hide();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
    }
}
