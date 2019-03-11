using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace LTTQ
{
    class Attract : Particle
    {
        [DllImport("shlwapi.dll")]  // đổi màu balls
        public static extern int ColorHLSToRGB(int H, int L, int S);
        private Brush brush; // màu 

        public Attract(float x, float y, int l, int t, int r, int b, int rad)
            : base(x, y, l, t, r, b)
        {
            Rad = rad;
            brush = new SolidBrush(ColorTranslator.FromWin32(ColorHLSToRGB(new Random().Next(240), 120, 240)));
            X = x;
            Y = y;
            State = 1;
        }

        public override void SetGrav(float x, float y)
        {
            GravX += x;
            GravY += y;
        }

        public override void Start()
        {
        }

        public override void Pause(bool b)
        {
            if (State == 1 && b)
                State = 2;
            else if (State == 2 && !b)
                State = 1;
        }

        public override void Update()
        {
            foreach (Particle b in MainForm.Balls)
            {
                if (!ReferenceEquals(b, this))
                {
                    float dx = b.X - X;
                    float dy = b.Y - Y;
                    float d = dx * dx + dy * dy;
                    float f = 20 * (Rad * b.Rad) / d;
                    d = (float)Math.Sqrt(d);
                    if (d < (Rad + b.Rad))
                    {
                        if (Rad <= b.Rad)
                            State = 0;
                        if (Rad >= b.Rad)
                            b.State = 0;
                        break;
                    }
                    dx = dx / d;
                    dy = dy / d;
                    SetGrav(dx * f / (Rad * Rad), dy * f / (Rad * Rad));
                }
            }
            if (State == 1)
            {
                SpeedX += GravX;
                SpeedY += GravY;
                X += SpeedX;
                Y += SpeedY;
                if (MainForm.grid != null)
                    MainForm.grid.ApplyExplosiveForce(5 * (Math.Abs(SpeedX) + Math.Abs(SpeedY)) / (Math.Sqrt(Rad) + 1), new Vector2(X, Y), Rad * 2.5);
                if (X + Rad < Bounds.Left || X - Rad > Bounds.Right || Y + Rad < Bounds.Top || Y - Rad > Bounds.Bottom)
                    State = 0;
            }
        }

        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(brush, X - Rad, Y - Rad, Rad * 2, Rad * 2);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
        }
    }
}
