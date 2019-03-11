using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace LTTQ
{
    public partial class HeloForm : Form
    {
        public string temp1;
        BeginForm bf = new LTTQ.BeginForm();
        int a = 6;
        public HeloForm()
        {
            InitializeComponent();

        }

        private void HeloForm_Load(object sender, EventArgs e)
        {
            label2.Text = "Hello " + temp1;
            timer2.Start();
            timer3.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            a--;
            if (a == 4)
            {
                label2.Text = "Hy vọng bạn cảm thấy hài lòng với chương trình của chúng tôi!";
            }

            if (a == 2)
            {
                label2.Text = "Chúc một ngày tốt lành!";
            }

            if (a <= 0)
            {
                timer2.Stop();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            processBar_ForFun1.Value += 1;
            if (processBar_ForFun1.Value == 100)
            {
                timer3.Stop();
                MainForm mf = new LTTQ.MainForm();
                mf.Show();
                this.Hide();
            }
        }
    }
}
