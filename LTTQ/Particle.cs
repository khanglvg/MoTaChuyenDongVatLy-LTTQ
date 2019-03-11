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
    public abstract class Particle  //lớp gốc
    {
        public float X { get; protected set; }
        public float Y { get; protected set; }

        public float Rad; //{ get; public set; }   // bán kính vật
        public float GravX { get; protected set; }  // cặp trọng lực
        public float GravY { get; protected set; }
        public float StartX { get; protected set; } // vị trí bắt đầu
        public float StartY { get; protected set; }
        public float SpeedX { get; protected set; }  // tốc độ di chuyển của vật
        public float SpeedY { get; protected set; }

        public int State;    // cờ trạng thái của vật
        public Stopwatch Watch;  // biến đồng hồ
        public Rectangle Bounds;  // khung màn hình


        public Particle(float x, float y, int l, int t, int r, int b)
        {
            this.Rad = 10;
            this.StartX = x;
            this.StartY = y;
            this.SpeedX = 0;
            this.SpeedY = 0;
            this.GravX = 0;
            this.GravY = 0;
            this.X = 0;
            this.Y = 0;
            this.Watch = new Stopwatch();
            this.Bounds = Rectangle.FromLTRB(l, t, r, b);
            this.State = 0;
        }

        public bool Outside(float x, float y)  // trả về true nếu vật ở ngoài màn hình đang xét => else = false
        {
            if (x < Bounds.Left || x > Bounds.Right || y < Bounds.Top || y > Bounds.Bottom)
                return true;
            return false;
        }

        public bool isOutMonitor(float x, float y)
        {
            if (x < Bounds.Left || x > Bounds.Right || y < Bounds.Top)
                return true;
            return false;
        }

        public bool isTouchGround(float x, float y)
        {
            if (y > Bounds.Bottom)
                return true;
            return false;
        }

        public float Time()
        {
            return ((float)Watch.ElapsedMilliseconds / 1000) * MainForm.SPEED;
        }

        public virtual bool SetStartPos(float x, float y)    // đặt lại vị trí vật
        {
            if (State == 0 && !Outside(x, y) && (StartX != x || StartY != y))
            {
                StartX = x;
                StartY = y;
                X = x;
                Y = y;
                return true;
            }
            return false;
        }

        public void SetSpeed(float x, float y)
        {
            if (State == 0)
            {
                SpeedX = x;
                SpeedY = y;
            }
        }

        public virtual void SetGrav(float x, float y)
        {
            if (State == 0)
            {
                GravX = x;
                GravY = y;
            }
        }

        public abstract void Start();  // bắt đầu
        public abstract void Update(); // cập nhật vị trí của vật
        public abstract void Pause(bool b); // tạm dừng
        public abstract void Draw(PaintEventArgs e);

        // virtual yêu cầu hàm cần đc thiết lập trong lớp cha
        // abstract không cần cài đặt trong lớp cha, ở lớp con cần thì override lại hàm
    }
}
