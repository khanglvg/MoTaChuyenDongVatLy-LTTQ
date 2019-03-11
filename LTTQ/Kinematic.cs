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
    class Kinematic : Particle // lớp chuyển động ném
    {
        public List<Point> Trace;
        public bool chuyen = false;
        Image img = global::LTTQ.Properties.Resources.ball;

        public Kinematic(float x, float y, int l, int t, int r, int b)
            : base(x, y, l, t, r, b)
        {
            Trace = new List<Point>();
        }

        public override bool SetStartPos(float x, float y)
        {
            if (base.SetStartPos(x, y))
                Trace.Clear();
            return true;
        }

        public override void Start()
        {
            State = 1;
            X = StartX;
            Y = StartY;
            Trace.Clear();
            Trace.Add(new Point((int)X, (int)Y));
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
                float time = Time();

                // ???
                X = StartX + (SpeedX * time + (GravX / 2) * time * time) / MainForm.SPACE;
                Y = StartY + (SpeedY * time + (GravY / 2) * time * time) / MainForm.SPACE;
                Trace.Add(new Point((int)X, (int)Y));

                // mainform.space cần đc mở rộng
                if (isTouchGround(X, Y))
                {
                    Watch.Stop();
                    State = 0;
                }
            }
        }

        public static Image resizeImage(Image imgToResize, int width, int height)
        {
            Size size = new Size(width, height);
            return (Image)(new Bitmap(imgToResize, size));
        }



        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // vẽ vật ở vị trí bắt đầu
            e.Graphics.DrawEllipse(new Pen(Color.Magenta, 2), StartX - Rad, StartY - Rad, Rad * 2, Rad * 2);

            // vẽ đường kẻ
            if (Trace.Count > 2)
            {
                //if (chuyen != true)
                //{
                //    e.Graphics.DrawLines(new Pen(Color.Lime, 2), Trace.ToArray());
                //}
                //else
                //{
                //    Trace.Clear();
                //    e.Graphics.DrawLines(new Pen(Color.Lime, 2), Trace.ToArray());
                //}
                e.Graphics.DrawLines(new Pen(Color.DarkRed, 7), Trace.ToArray());
            }


            

            // vẽ vật đang di chuyển
            if (!(State == 0 && X == StartX && Y == StartY && isTouchGround(X, Y)))
            {
                e.Graphics.DrawImage(resizeImage(img, 20, 20), X - Rad, Y - Rad);
                // e.Graphics.DrawEllipse(new Pen(Color.Black), X - Rad, Y - Rad, Rad * 2, Rad * 2);
                e.Graphics.DrawLine(new Pen(Color.Black), X , Y , X , Y  - 20); // vẽ đường kẻ dọc
                e.Graphics.DrawLine(new Pen(Color.Black), X, Y - 20, X + 20, Y - 20); // vẽ đường kẻ ngang
                PointF point = new PointF(X + 20 , Y  - 30);
                string getObjectPosition = "X = " + X.ToString() + "\n" + "Y = " + Y.ToString();
                e.Graphics.DrawString(getObjectPosition, new Font("Arial", 9), new SolidBrush(Color.Black), point);
            }

        }



        // e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
    }
}

