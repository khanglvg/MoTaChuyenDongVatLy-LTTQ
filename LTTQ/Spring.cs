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
    class Spring : Particle //lớp lò xo
    {
        private float time, speed;
        private int nodes = 60; // số nút của đường kẻ của lò xo
        private int length = 200; // độ dài từ khoảng treo đến vị trí quả bi
        private int[] node; // tập các nút của đường vẽ lò xo
       
        //Change variable function:
        //GravY Gravity 270
        //GravX Delta
        //SpeedX Weight
        //SpeedY Softness

        public Spring(float x, float y, int l, int t, int r, int b)
            : base(x, y, l, t, r, b)
        {
            time = 0;
            speed = 0;
            StartY = 200;
            X = StartX = 400;
            node = new int[nodes];
            for (int i = 0; i < nodes; i++)
            {
                var temp = i % 4;
                if (temp == 1)
                    node[i] = 10;
                else if (temp == 3)
                    node[i] = -10;
                else
                    node[i] = 0;
            }
        }

        public override void Start()
        {
            State = 1;
            time = 0;
            speed = 0;
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
                float t = Time() - time, accel;
                time = Time();
                accel = GravY - (GravX * SpeedY / SpeedX); // công thức của gia tốc
                speed += accel * t;
                GravX += speed * t;
            }
        }

        public static Image resizeImage(Image imgToResize, int width, int height)
        {
            Size size = new Size(width, height);
            
            try { return (Image)(new Bitmap(imgToResize, size)); }
            catch { return (Image)(new Bitmap(imgToResize, new Size(1,1)));  }

        }


        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // vẽ quả bi trên
            e.Graphics.DrawEllipse(new Pen(Color.Magenta, 2), StartX - 10, StartY - 10, 10 * 2, 10 * 2);

            // khoang cach giua cac duong nodes
            float l = ((length + GravX) / nodes) / MainForm.SPACE;

            // vẽ đường kẻ lo xo 
            for (int i = 1; i < nodes; i++)
                e.Graphics.DrawLine(new Pen(Color.Lime, 2), StartX + node[i] / MainForm.SPACE, StartY + l * i, StartX + node[i - 1] / MainForm.SPACE, StartY + l * (i - 1));

            // vẽ bi treo trên lò xo

            Image img = global::LTTQ.Properties.Resources.ball;

            e.Graphics.DrawImage(resizeImage(img, (int)Rad, (int)Rad), X - Rad/2, StartY + l * (nodes - 1));
            //e.Graphics.DrawEllipse(new Pen(Color.Black), X - Rad, StartY + l * (nodes - 1) - Rad, Rad * 2, Rad * 2);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
        }
    }
}
