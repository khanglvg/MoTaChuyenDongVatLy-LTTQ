using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;

namespace LTTQ
{
    class CustomBox : TextBox
    {
        private bool Float = false, Nega = false;
        private int Max = 4;

        [Description("Only number text box")]
        [Category("LTTQ")]
        [DefaultValue(true)]

        public void Set(int max, bool fl, bool ne)
        {
            Float = fl;
            Nega = ne;
            Text = "";
            Max = max;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (Text.Length > Max)
                e.Handled = true;
            else
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != 46)
                    e.Handled = true;
                if (e.KeyChar == 46 && (Text.Contains('.') || !Float))
                    e.Handled = true;
                if (e.KeyChar == '-' && (Text.Length != 0 || !Nega))
                    e.Handled = true;
            }
            if (e.KeyChar == 8)
                e.Handled = false;
            base.OnKeyPress(e);
        }
    }
}
