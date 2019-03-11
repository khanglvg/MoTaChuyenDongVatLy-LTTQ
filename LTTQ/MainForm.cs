using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using OpenCvSharp;
using ImageMagick;
using System.IO;

namespace LTTQ
{
    public partial class MainForm : Form
    {
        public static float SPEED = 1;
        public static int BB, FPS = 50, SPACE = 1, STATE = 0;
        public static List<Particle> Balls = new List<Particle>();
        public static Grid grid = null;
        static CustomBox[] Input = new CustomBox[3];
        static Timer Step = new Timer();
        private int buttonChangeImageFlat = 1; //cờ bắt tính hiệu click vào icon pause/play  1 là k dừng, 2 là dừng
        Bitmap bmp;
        Graphics gr;
        SaveFileDialog sdl = new SaveFileDialog();
        // private CvVideoWriter _videoWriter;
        public MainForm()
        {

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
            SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();

            Bar_Scroll();
            TimeBar.MouseWheel += (sender, e) => ((HandledMouseEventArgs)e).Handled = true;
            SpaceBar.MouseWheel += (sender, e) => ((HandledMouseEventArgs)e).Handled = true;

            BB = control.Height + 400;

            for (int i = 0; i < Input.Length; i++)
            {
                Input[i] = new CustomBox();
                Input[i].Location = new System.Drawing.Point(130, 20 * i + 5);
                Input[i].Size = new System.Drawing.Size(40, 20);
                control.Controls.Add(Input[i]);
            }
            Step.Interval = (1000 / FPS);
            Step.Tick += new EventHandler(Step_Tick);
            Step.Start();
            Start.AutoCheck = false;
            TypeBox.SelectedIndex = 0;

            // _videoWriter = new CvVideoWriter("khang.avi", FourCC.MJPG, 30, new CvSize(1060, 705));
        }

        private void Step_Tick(object sender, EventArgs e)
        {
            Invalidate();
            if (Start.Checked)
            {
                if (!(buttonChangeImageFlat == 2))
                {
                    foreach (Particle b in Balls)
                    //    b.Update();
                    if (grid != null)
                        grid.Update();
                }

                switch (STATE)
                {
                    case 0:
                        foreach (Particle b in Balls)
                        {
                            if (b.State == 0)
                                Start.Checked = false;
                            label3.Text = "Vận tốc rơi: " + (b.SpeedY + b.GravY * b.Time()) + "m/s";
                            label4.Text = "Thời gian: " + b.Time() + "s";
                        }
                        break;

                    case 1:
                        foreach (Particle b in Balls)
                        {
                            label2.Text = "Vận tốc góc: " + (b.SpeedY / (float)Math.PI * 180);
                            label3.Text = "Thời gian: " + b.Time() + "s";
                        }
                        break;

                    case 2:
                        foreach (Particle b in Balls)
                        {
                            label2.Text = "Khoảng cách giãn: " + b.GravX + "m";
                            label3.Text = "Thời gian: " + b.Time() + "s";
                        }
                        break;

                    case 3:
                        Balls = Balls.Where(b => (b.State != 0)).ToList();
                        label5.Text = "Số lượng vật thể: " + Balls.Count;
                        break;
                }
            }
            else if (!Start.Checked)
            {

                switch (STATE)
                {
                    case 0:
                        foreach (Particle b in Balls)
                        {
                            float temp;
                            if (float.TryParse(Input[2].Text, out temp))
                                b.SetStartPos(100 / SPACE, BB - temp / SPACE);
                            else
                                b.SetStartPos(100 / SPACE, b.StartY);
                        }
                        break;

                    case 1:
                        foreach (Particle b in Balls)
                        {
                            float temp;
                            b.SetStartPos(400, control.Height + 100);
                            if (float.TryParse(Input[0].Text, out temp))
                                b.SetGrav(Math.Min(temp, 400 * SPACE), 10);
                            if (float.TryParse(Input[1].Text, out temp))
                            {
                                if (temp > 90)
                                    temp = 90;
                                else if (temp < -90)
                                    temp = -90;
                                b.SetSpeed(temp * (float)Math.PI / 180, 0);
                            }
                        }
                        break;

                    case 2:
                        foreach (Particle b in Balls)
                        {
                            b.SetGrav(0, 10);
                            try
                            {
                                b.Rad = int.Parse(Input[1].Text);
                            }
                            catch
                            { }
                        }
                        break;

                    case 3:
                        if (grid == null)
                            grid = new Grid(new Rectangle(0, 100, Width, Height), new Vector2(20));
                        label5.Text = "Số lượng vật thể: 0";
                        break;
                }
            }
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            buttonChangeImageFlat = 1;
            statusStrip1.Visible = false;
            this.button1.BackgroundImage = global::LTTQ.Properties.Resources.pause;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;



            if (Start.Checked)
            {

                Start.Checked = false;
                foreach (Particle b in Balls)
                    b.State = 0;
                if (STATE == 3)
                {
                    Balls.Clear();
                    this.button1.BackgroundImage = global::LTTQ.Properties.Resources.pause;
                    grid = null;
                }

            }
            else
            {

                Start.Checked = true;
                switch (STATE)
                {
                    case 0:
                        foreach (Particle b in Balls)
                        {
                            float hướng, lực, x, y;
                            float.TryParse(Input[1].Text, out hướng);
                            if (hướng > 180)
                                hướng = 180;
                            else if (hướng < 0)
                                hướng = 0;
                            Input[1].Text = (hướng).ToString();
                            hướng *= (float)Math.PI / 180;
                            float.TryParse(Input[0].Text, out lực);
                            x = lực * (float)Math.Sin(hướng);
                            y = lực * (float)Math.Cos(hướng);
                            b.SetSpeed(x, y);
                            b.SetGrav(0, 10);
                            double t = 0, h = (BB - b.StartY) * SPACE;
                            if (y < 0)
                            {
                                t = -(y / 10);
                                h -= (y * t + 5 * t * t);
                                t += Math.Sqrt(2 * h / 10);
                            }
                            else
                            {
                                double v = Math.Sqrt(20 * h + y * y);
                                t = (v - y) / 10;
                            }
                            label1.Text = "Độ cao cực đại: " + (float)h + "m";
                            label2.Text = "Tầm xa cực đại: " + (float)Math.Max(x * t, 0) + "m";
                            b.Start();
                        }
                        break;

                    case 1:
                        foreach (Particle b in Balls)
                        {
                            double chuki, power = 1;
                            power += Math.Pow(b.SpeedX, 2) * (float)1 / 16;
                            power += Math.Pow(b.SpeedX, 4) * (float)11 / 3072;
                            power += Math.Pow(b.SpeedX, 6) * (float)173 / 737280;
                            chuki = 2 * Math.PI * Math.Sqrt(Balls[0].GravX / b.GravY) * power;
                            label1.Text = "Chu kì con lắc: " + (float)chuki + "s";
                            Input[1].Text = (b.SpeedX / (float)Math.PI * 180).ToString();
                            Input[0].Text = b.GravX.ToString();
                            b.Start();
                        }
                        break;

                    case 2:
                        foreach (Particle b in Balls)
                        {
                            int temp;
                            if (int.TryParse(Input[1].Text, out temp))
                                b.SetSpeed(Math.Max(temp, 1), Balls[0].SpeedY);
                            if (int.TryParse(Input[0].Text, out temp))
                                b.SetSpeed(Balls[0].SpeedX, Math.Max(temp, 1));
                            Input[1].Text = Balls[0].SpeedX.ToString();
                            Input[0].Text = Balls[0].SpeedY.ToString();
                            label1.Text = "Chu kì co giãn: " + (float)(2 * Math.PI * Math.Sqrt(b.SpeedX / b.SpeedY)) + "s";
                            b.Start();
                        }
                        break;
                }
            }
        }

        // hàm kẻ lưới
        private void LTTQ_Paint(object sender, PaintEventArgs e)
        {
            switch (STATE)
            {
                case 0:
                    for (int i = 0; i < Width; i += (int)(100 / SPACE))
                        e.Graphics.DrawLine(new Pen(Color.Blue), i, control.Height, i, Height);
                    for (int i = control.Height; i < Height; i += (int)(100 / SPACE))
                        e.Graphics.DrawLine(new Pen(Color.Blue), 0, i, Width, i);
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 139, 90, 0)), 0, BB, Width, Height);
                    break;

                case 1:
                    for (int i = 0; i < Width; i += (int)(100 / SPACE))
                        e.Graphics.DrawLine(new Pen(Color.Blue), i, control.Height, i, Height);
                    for (int i = control.Height; i < Height; i += (int)(100 / SPACE))
                        e.Graphics.DrawLine(new Pen(Color.Blue), 0, i, Width, i);
                    break;

                case 2:
                    for (int i = 0; i < Width; i += (int)(100 / SPACE))
                        e.Graphics.DrawLine(new Pen(Color.Blue), i, control.Height, i, Height);
                    for (int i = control.Height; i < Height; i += (int)(100 / SPACE))
                        e.Graphics.DrawLine(new Pen(Color.Blue), 0, i, Width, i);
                    break;

                case 3:
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 0, 0, 0)), 0, control.Height, Width, Height);
                    if (grid != null)
                        grid.Draw(e);
                    break;
            }
            foreach (Particle b in Balls)
                b.Draw(e);
        }



        private void Start_CheckedChanged(object sender, EventArgs e)
        {
            if (Start.Checked)
            {
                control.Enabled = false;
                buttonGo.Text = "Hủy";
                button2.BackgroundImage = ToGrayScale((Bitmap)button2.BackgroundImage);
                button2.Enabled = false;
            }
            else
            {
                control.Enabled = true;
                buttonGo.Text = "Chạy";
                button2.BackgroundImage = global::LTTQ.Properties.Resources.EXIT;
                button2.Enabled = true;
            }
        }

        // lấy ra loại chuyển động (theo thứ tự)

        private void TypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Balls.Clear();
            STATE = TypeBox.SelectedIndex;
            switch (TypeBox.SelectedIndex)
            {
                case 0:
                    Balls.Add(new Kinematic(Width / 2, BB / 2 + control.Height, 0, control.Height, Width, BB));
                    Input_txt1.Text = "Vận tốc ném: (m/s)";
                    Input_txt2.Text = "Hướng ném: (độ)";
                    Input_txt3.Text = "Độ cao đầu: (m)";
                    Input[0].Set(2, true, false);  //nega là số âm,  fl số thực
                    Input[0].Text = "100";
                    Input[1].Set(2, true, false);
                    Input[1].Text = "135";
                    Input[2].Set(2, false, false);
                    Input[2].Text = "100";
                    Input[2].Visible = true;
                    Input[2].ReadOnly = false;
                    label1.Text = "Độ cao cực đại:";
                    label2.Text = "Tầm xa cực đại:";
                    label3.Text = "Vận tốc rơi: ";
                    label4.Text = "Thời gian: ";
                    label5.Text = "Gia tốc trọng trường: 10m/s2";
                    break;

                case 1:
                    Balls.Add(new Pendulum(Width / 2, BB / 2 + control.Height, 0, control.Height, Width, Height));
                    Input_txt1.Text = "Độ dài tay lắc: (m)";
                    Input_txt2.Text = "Góc thả: (độ)";
                    Input_txt3.Text = "";
                    Input[0].Set(2, true, false);
                    Input[0].Text = "150";
                    Input[1].Set(2, true, true);
                    Input[1].Text = "30";
                    Input[2].Visible = false;
                    Input[2].ReadOnly = true;
                    label1.Text = "Chu kì con lắc:";
                    label2.Text = "Vận tốc góc:";
                    label3.Text = "Thời gian:";
                    label4.Text = "";
                    label5.Text = "Gia tốc trọng trường: 10m/s2";
                    break;

                case 2:

                    Input_txt1.Text = "Độ cứng lò xo: (N/m)";
                    Input_txt2.Text = "Khối lượng vật: (kg)";
                    Input_txt3.Text = "";
                    Input[0].Set(2, false, false);
                    Input[0].Text = "5";
                    Input[1].Set(2, false, false);
                    Input[1].Text = "20";


                    Input[2].Visible = false;
                    Input[2].ReadOnly = true;
                    label1.Text = "Chu kì co giãn:";
                    label2.Text = "Khoảng cách giãn:";
                    label3.Text = "Thời gian:";
                    label4.Text = "";
                    label5.Text = "Gia tốc trọng trường: 10m/s2";
                    Balls.Add(new Spring(Width / 2, BB / 2 + control.Height, 0, control.Height, Width, Height));
                    break;

                case 3:
                    Input_txt1.Text = "Lực hấp dẫn 1:";
                    Input_txt2.Text = "Lực hấp dẫn 2";
                    Input_txt3.Text = "";
                    Input[0].Set(1, false, false);
                    Input[0].Text = "10";
                    Input[1].Set(1, false, false);
                    Input[1].Text = "25";
                    Input[2].Visible = false;
                    Input[2].ReadOnly = true;
                    label1.Text = "*Không gian và thời gian vô hiệu trong chế độ này*";
                    label2.Text = "--Chỉ khả dụng khi chạy";
                    label3.Text = "--Click chuột trái/phải để tạo vật hấp dẫn 1/2";
                    label4.Text = "";
                    break;
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (Start.Checked)
            {
                if (buttonChangeImageFlat == 1)
                    buttonChangeImageFlat = 2;
                else
                    buttonChangeImageFlat = 1;

                if (buttonChangeImageFlat == 2)
                    foreach (Particle b in Balls)
                        b.Pause(true);
                else
                    foreach (Particle b in Balls)
                        b.Pause(false);


                if (buttonChangeImageFlat == 2)
                {
                    this.button1.BackgroundImage = global::LTTQ.Properties.Resources.play;
                    this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                }
                else
                {
                    this.button1.BackgroundImage = global::LTTQ.Properties.Resources.pause;
                    this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            BeginForm bf = new BeginForm();
            bf.Show();
        }



        //kéo thả ball trong con lắc đơn
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && STATE == 1 && !Start.Checked)
            {
                foreach (Particle b in Balls)
                {
                    double t = e.Y - b.StartY;
                    double temp = 90;
                    if (t <= 0)
                        temp *= Math.Sign(e.X - b.StartX);
                    else
                    {
                        temp = (double)((e.X - b.StartX) / t);
                        temp = Math.Atan(temp) / Math.PI * 180;
                    }
                    Input[1].Text = ((int)temp).ToString();
                }
            }
        }

        // thanh kéo không gian và thời gian
        private void Bar_Scroll(object sender, EventArgs e)
        {
            Bar_Scroll();
        }



        private void Bar_Scroll()
        {
            switch (SpaceBar.Value)
            {
                case 0:
                    SpaceLabel.Text = "Không gian nhỏ";
                    SPACE = 1;
                    break;

                case 1:
                    SpaceLabel.Text = "Không gian vừa";
                    SPACE = 2;
                    break;

                case 2:
                    SpaceLabel.Text = "Không gian lớn";
                    SPACE = 4;
                    break;
                case 3:
                    SpaceLabel.Text = "Không gian siêu vũ trụ";
                    SPACE = 8;
                    break;
            }
            switch (TimeBar.Value)
            {
                case 0:
                    SPEED = 0.25f;
                    break;

                case 1:
                    SPEED = 0.5f;
                    break;

                case 2:
                    SPEED = 1;
                    break;

                case 3:
                    SPEED = 2;
                    break;

                case 4:
                    SPEED = 4;
                    break;
            }
            TimeBox.Text = "Thời Gian x" + SPEED;
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (STATE == 3 && Start.Checked)
            {
                if (e.Button == MouseButtons.Left)
                    Balls.Add(new Attract(e.X, e.Y, 0, control.Height, Width, Height, int.Parse(Input[0].Text)));
                else if (e.Button == MouseButtons.Right)
                    Balls.Add(new Attract(e.X, e.Y, 0, control.Height, Width, Height, int.Parse(Input[1].Text)));
                if (buttonChangeImageFlat == 2)
                    Balls[Balls.Count - 1].Pause(true);
            }
            //if (grid != null)
            //    grid.ApplyExplosiveForce(-100, new Vector2(e.X,e.Y), 1000);
        }

        private static Bitmap ToGrayScale(Bitmap original)
        {
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            Graphics g = Graphics.FromImage(newBitmap);

            ColorMatrix colorMatrix = new ColorMatrix
                (
                new float[][]
                {
                    new float[] {0.299f, 0.299f, 0.299f, 0, 0},
                    new float[] {0.587f, 0.587f, 0.587f, 0, 0},
                    new float[] {0.114f, 0.114f, 0.114f, 0, 0},
                    new float[] {0,0,0,1,0},
                    new float[] {0,0,0,0,1}
                }
                );

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);

            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
            g.Dispose();
            return newBitmap;
        }


        string filePath;

        int dem = 0;
        private void timer_TakePicss_Tick(object sender, EventArgs e)
        {
            dem++;
            if (Start.Checked)
            {
                if (buttonChangeImageFlat == 2)
                    timer_TakePicss.Stop();
                else
                {
                    _btnTakePic_Click(sender, e);
                    filePath = Application.StartupPath + "\\Picture\\" + dem.ToString() + ".jpg";
                    //var tmpImage = new IplImage(1060, 705, BitDepth.U8, 3);
                    // tmpImage.CopyFrom(new Bitmap(pictureBox1.Image));
                    //_videoWriter.WriteFrame(tmpImage);
                    pictureBox1.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    statusStrip1.Visible = true;
                    _lbTrangThai.Text = "Rendering ...";
                }
            }
            else
            {
                timer_TakePicss.Stop();
                try
                {
                    VideoMaker();

                    //delete all images
                    System.IO.DirectoryInfo di = new DirectoryInfo(@"Picture\");

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }

                    statusStrip1.Visible = false;
                    MessageBox.Show("Video is exported !");

                }
                catch
                { }

            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //  _videoWriter.Dispose();
        }

        private void _chboxXemHinh_CheckedChanged(object sender, EventArgs e)
        {
            if (_chboxXemHinh.Checked)
            {
                pictureBox1.Visible = true;
            }
            else
                pictureBox1.Visible = false;
        }



        private void _btnTakePicss_Click(object sender, EventArgs e)
        {
            dem = 0;
            timer_TakePicss.Interval = 20;
            timer_TakePicss.Start();
            timer_TakePicss.Tick += new EventHandler(timer_TakePicss_Tick);
        }


        private void _btnTakePic_Click(object sender, EventArgs e)
        {
            try
            {
                var mainformPic = MainForm.ActiveForm;
                bmp = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height );
                gr = Graphics.FromImage(bmp);
                gr.CopyFromScreen(0, 0, 0, 0, new Size(bmp.Width, bmp.Height));
                pictureBox1.Image = bmp;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                this.statusStrip1.Visible = true;
                _lbTrangThai.Text = "Done!";
            }
            catch { }


        }

        private void _btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                sdl.Filter = "Image|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
                if (sdl.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(sdl.FileName);
                    _lbTrangThai.Text = "Save Picture Succeed!";
                }
            }
            catch
            {
                this.statusStrip1.Visible = true;
                _lbTrangThai.Text = "Save Picture Failed!";
            }

        }

        private void VideoMaker()
        {
            using (MagickImageCollection collection = new MagickImageCollection())
            {

                // đếm số ảnh trong thư mục
                int fCount = Directory.GetFiles("Picture/", "*", SearchOption.AllDirectories).Length;

                for (int i = 1; i <= fCount; i++)
                {
                    collection.Add("Picture/" + i + ".jpg");  // thư mục Picture chứa ảnh trong debug
                    collection[i - 1].AnimationDelay = 1;   // thời gian delay giữa các hình
                }

                // Optionally reduce colors
                QuantizeSettings settings = new QuantizeSettings();
                settings.Colors = 256;
                collection.Quantize(settings);

                // Optionally optimize the images (images should have the same size).
                collection.Optimize();

                // Save gif
                collection.Write("Video.gif"); // lưu vào thư mục debug

            }
        }


    }
}