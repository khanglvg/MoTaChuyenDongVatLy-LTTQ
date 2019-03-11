using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;

namespace LTTQ
{
    class Pendulum : Particle // lớp con mô tả con lắc đồng hồ
    {
        private float time;
        //Change variable function:
        //GravY Gravity 270
        //GravX Arm length
        //SpeedX Angle
        //SpeedY Angle velocity
        
        public Pendulum(float x, float y, int l, int t, int r, int b)
            : base(x, y, l, t, r, b)
        {
            time = 0;
        }

        public override void Start()
        {
            
            State = 1;
            time = 0;
            Watch.Restart();
        }

        public override void Pause(bool b)  
        {
            if (State == 1 && b)
            {
                Watch.Stop();
                State = 2;
            }
            else if (State == 2 && !b)
            {
                Watch.Start();
                State = 1;
            }
        }

        public override void Update()
        {
            if (State == 1)
            {
                float t = Time() - time, angleAccel;
                time = Time();
                angleAccel = -(GravY / GravX) * (float)Math.Sin(SpeedX); // gia toc goc 
                SpeedY += angleAccel * t;  
                SpeedX += SpeedY * t;
            }
        }

        public static Image resizeImage(Image imgToResize, int width, int height)
        {
            Size size = new Size(width, height);
            return (Image)(new Bitmap(imgToResize, size));
        }

        
        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; // vẽ mượt hơn

            // vẽ hình tròn trên đầu sợi dây
            e.Graphics.DrawEllipse(new Pen(Color.Magenta, 2), StartX - Rad, StartY - Rad, Rad * 2, Rad * 2); 
            
            // vị trí bắt đâu, mainform.space là khoảng không gian (lớn vừa nhỏ)
            X = StartX + (float)Math.Sin(SpeedX) * GravX / MainForm.SPACE; 
            Y = StartY + (float)Math.Cos(SpeedX) * GravX / MainForm.SPACE;

         

            // vẽ sợi dây
            e.Graphics.DrawLine(new Pen(Color.Lime, 2), StartX, StartY, X, Y);

            // vẽ con lắc
            Image img = global::LTTQ.Properties.Resources.ball;
            e.Graphics.DrawImage(resizeImage(img, 20, 20), X - Rad, Y - Rad);

            // vẽ tọa độ con lắc
            PointF point = new PointF(X , Y + 20);
            string getObjectPosition = "X = " + X.ToString() + "\n" + "Y = " + Y.ToString();
            e.Graphics.DrawString(getObjectPosition, new Font("Arial", 9), new SolidBrush(Color.Black), point);

            // vẽ góc giữa con lắc và trục đứng
            string angel = (Math.Abs(SpeedX)/ Math.PI *180).ToString(); // speedX là góc tính rad
            PointF point1 = new PointF(StartX + 30, StartY);
            e.Graphics.DrawString(angel, new Font("Arial", 9), new SolidBrush(Color.Black), point1 );

            // e.Graphics.DrawEllipse(new Pen(Color.Black), X - Rad, Y - Rad, Rad * 2, Rad * 2);

            //  e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
        }
    }
}
