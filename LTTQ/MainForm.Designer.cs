namespace LTTQ
{
    public partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.control = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.SpaceLabel = new System.Windows.Forms.Label();
            this.SpaceBar = new System.Windows.Forms.TrackBar();
            this.TimeBox = new System.Windows.Forms.GroupBox();
            this.TimeBar = new System.Windows.Forms.TrackBar();
            this.TypeBox = new System.Windows.Forms.ComboBox();
            this.Input_txt3 = new System.Windows.Forms.Label();
            this.Input_txt2 = new System.Windows.Forms.Label();
            this.Input_txt1 = new System.Windows.Forms.Label();
            this.buttonGo = new System.Windows.Forms.Button();
            this.Stat = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Command = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._chboxXemHinh = new System.Windows.Forms.CheckBox();
            this._btnTakePicss = new System.Windows.Forms.Button();
            this._btnSave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this._btnTakePic = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._lbTrangThai = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer_TakePicss = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpaceBar)).BeginInit();
            this.TimeBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeBar)).BeginInit();
            this.Stat.SuspendLayout();
            this.Command.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // control
            // 
            this.control.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.control.Controls.Add(this.label6);
            this.control.Controls.Add(this.SpaceLabel);
            this.control.Controls.Add(this.SpaceBar);
            this.control.Controls.Add(this.TimeBox);
            this.control.Controls.Add(this.TypeBox);
            this.control.Controls.Add(this.Input_txt3);
            this.control.Controls.Add(this.Input_txt2);
            this.control.Controls.Add(this.Input_txt1);
            this.control.Location = new System.Drawing.Point(0, 0);
            this.control.Margin = new System.Windows.Forms.Padding(0);
            this.control.Name = "control";
            this.control.Size = new System.Drawing.Size(533, 155);
            this.control.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 99);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Chọn loại chuyển động:";
            // 
            // SpaceLabel
            // 
            this.SpaceLabel.AutoSize = true;
            this.SpaceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpaceLabel.Location = new System.Drawing.Point(247, 10);
            this.SpaceLabel.Margin = new System.Windows.Forms.Padding(0);
            this.SpaceLabel.Name = "SpaceLabel";
            this.SpaceLabel.Size = new System.Drawing.Size(111, 18);
            this.SpaceLabel.TabIndex = 4;
            this.SpaceLabel.Text = "Không gian nhỏ";
            // 
            // SpaceBar
            // 
            this.SpaceBar.AutoSize = false;
            this.SpaceBar.LargeChange = 1;
            this.SpaceBar.Location = new System.Drawing.Point(367, 10);
            this.SpaceBar.Margin = new System.Windows.Forms.Padding(0);
            this.SpaceBar.Maximum = 3;
            this.SpaceBar.Name = "SpaceBar";
            this.SpaceBar.Size = new System.Drawing.Size(156, 36);
            this.SpaceBar.SmallChange = 0;
            this.SpaceBar.TabIndex = 4;
            this.SpaceBar.Value = 2;
            this.SpaceBar.Scroll += new System.EventHandler(this.Bar_Scroll);
            // 
            // TimeBox
            // 
            this.TimeBox.Controls.Add(this.TimeBar);
            this.TimeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeBox.Location = new System.Drawing.Point(250, 63);
            this.TimeBox.Margin = new System.Windows.Forms.Padding(0);
            this.TimeBox.Name = "TimeBox";
            this.TimeBox.Padding = new System.Windows.Forms.Padding(0);
            this.TimeBox.Size = new System.Drawing.Size(280, 63);
            this.TimeBox.TabIndex = 2;
            this.TimeBox.TabStop = false;
            this.TimeBox.Text = "Thời Gian x1";
            // 
            // TimeBar
            // 
            this.TimeBar.AutoSize = false;
            this.TimeBar.LargeChange = 1;
            this.TimeBar.Location = new System.Drawing.Point(7, 18);
            this.TimeBar.Margin = new System.Windows.Forms.Padding(0);
            this.TimeBar.Maximum = 4;
            this.TimeBar.Name = "TimeBar";
            this.TimeBar.Size = new System.Drawing.Size(267, 33);
            this.TimeBar.SmallChange = 0;
            this.TimeBar.TabIndex = 3;
            this.TimeBar.Value = 2;
            this.TimeBar.Scroll += new System.EventHandler(this.Bar_Scroll);
            // 
            // TypeBox
            // 
            this.TypeBox.BackColor = System.Drawing.SystemColors.Menu;
            this.TypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeBox.FormattingEnabled = true;
            this.TypeBox.Items.AddRange(new object[] {
            "Chuyển động ném",
            "Quỹ đạo con lắc",
            "Co giãn lò xo",
            "Lực hấp dẫn"});
            this.TypeBox.Location = new System.Drawing.Point(9, 123);
            this.TypeBox.Margin = new System.Windows.Forms.Padding(0);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.Size = new System.Drawing.Size(225, 24);
            this.TypeBox.TabIndex = 3;
            this.TypeBox.SelectedIndexChanged += new System.EventHandler(this.TypeBox_SelectedIndexChanged);
            // 
            // Input_txt3
            // 
            this.Input_txt3.AutoSize = true;
            this.Input_txt3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_txt3.Location = new System.Drawing.Point(10, 50);
            this.Input_txt3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Input_txt3.Name = "Input_txt3";
            this.Input_txt3.Size = new System.Drawing.Size(91, 18);
            this.Input_txt3.TabIndex = 2;
            this.Input_txt3.Text = "Độ Cao Đầu";
            // 
            // Input_txt2
            // 
            this.Input_txt2.AutoSize = true;
            this.Input_txt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_txt2.Location = new System.Drawing.Point(10, 28);
            this.Input_txt2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Input_txt2.Name = "Input_txt2";
            this.Input_txt2.Size = new System.Drawing.Size(83, 18);
            this.Input_txt2.TabIndex = 1;
            this.Input_txt2.Text = "Hướng Đầu";
            // 
            // Input_txt1
            // 
            this.Input_txt1.AutoSize = true;
            this.Input_txt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_txt1.Location = new System.Drawing.Point(10, 7);
            this.Input_txt1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Input_txt1.Name = "Input_txt1";
            this.Input_txt1.Size = new System.Drawing.Size(94, 18);
            this.Input_txt1.TabIndex = 0;
            this.Input_txt1.Text = "Vận Tốc Đầu";
            // 
            // buttonGo
            // 
            this.buttonGo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonGo.ForeColor = System.Drawing.Color.Black;
            this.buttonGo.Location = new System.Drawing.Point(3, 23);
            this.buttonGo.Margin = new System.Windows.Forms.Padding(0);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(93, 31);
            this.buttonGo.TabIndex = 8;
            this.buttonGo.Text = "Go";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // Stat
            // 
            this.Stat.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Stat.Controls.Add(this.label5);
            this.Stat.Controls.Add(this.label3);
            this.Stat.Controls.Add(this.label2);
            this.Stat.Controls.Add(this.label1);
            this.Stat.Controls.Add(this.label4);
            this.Stat.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold);
            this.Stat.ForeColor = System.Drawing.Color.Lime;
            this.Stat.Location = new System.Drawing.Point(874, 0);
            this.Stat.Margin = new System.Windows.Forms.Padding(0);
            this.Stat.Name = "Stat";
            this.Stat.Size = new System.Drawing.Size(407, 155);
            this.Stat.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 124);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "label5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "label4";
            // 
            // Command
            // 
            this.Command.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Command.Controls.Add(this.groupBox1);
            this.Command.Location = new System.Drawing.Point(533, 0);
            this.Command.Margin = new System.Windows.Forms.Padding(0);
            this.Command.Name = "Command";
            this.Command.Size = new System.Drawing.Size(341, 155);
            this.Command.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._chboxXemHinh);
            this.groupBox1.Controls.Add(this._btnTakePicss);
            this.groupBox1.Controls.Add(this._btnSave);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this._btnTakePic);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.buttonGo);
            this.groupBox1.Controls.Add(this.Start);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 149);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control Center";
            // 
            // _chboxXemHinh
            // 
            this._chboxXemHinh.AutoSize = true;
            this._chboxXemHinh.Location = new System.Drawing.Point(114, 120);
            this._chboxXemHinh.Name = "_chboxXemHinh";
            this._chboxXemHinh.Size = new System.Drawing.Size(91, 21);
            this._chboxXemHinh.TabIndex = 18;
            this._chboxXemHinh.Text = "Xem Hình";
            this._chboxXemHinh.UseVisualStyleBackColor = true;
            this._chboxXemHinh.CheckedChanged += new System.EventHandler(this._chboxXemHinh_CheckedChanged);
            // 
            // _btnTakePicss
            // 
            this._btnTakePicss.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_btnTakePicss.BackgroundImage")));
            this._btnTakePicss.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._btnTakePicss.Location = new System.Drawing.Point(277, 62);
            this._btnTakePicss.Name = "_btnTakePicss";
            this._btnTakePicss.Size = new System.Drawing.Size(58, 51);
            this._btnTakePicss.TabIndex = 17;
            this._btnTakePicss.UseVisualStyleBackColor = true;
            this._btnTakePicss.Click += new System.EventHandler(this._btnTakePicss_Click);
            // 
            // _btnSave
            // 
            this._btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_btnSave.BackgroundImage")));
            this._btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._btnSave.Location = new System.Drawing.Point(174, 62);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(59, 53);
            this._btnSave.TabIndex = 8;
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(221, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 46);
            this.button2.TabIndex = 6;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // _btnTakePic
            // 
            this._btnTakePic.BackColor = System.Drawing.Color.Transparent;
            this._btnTakePic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_btnTakePic.BackgroundImage")));
            this._btnTakePic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._btnTakePic.Location = new System.Drawing.Point(114, 62);
            this._btnTakePic.Name = "_btnTakePic";
            this._btnTakePic.Size = new System.Drawing.Size(54, 52);
            this._btnTakePic.TabIndex = 7;
            this._btnTakePic.UseVisualStyleBackColor = false;
            this._btnTakePic.Click += new System.EventHandler(this._btnTakePic_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(6, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 71);
            this.button1.TabIndex = 16;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Start
            // 
            this.Start.AutoSize = true;
            this.Start.Location = new System.Drawing.Point(107, 28);
            this.Start.Margin = new System.Windows.Forms.Padding(0);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(61, 21);
            this.Start.TabIndex = 15;
            this.Start.Text = "Chạy";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.CheckedChanged += new System.EventHandler(this.Start_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lbTrangThai});
            this.statusStrip1.Location = new System.Drawing.Point(0, 696);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1280, 24);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // _lbTrangThai
            // 
            this._lbTrangThai.Font = new System.Drawing.Font("Arial", 20F);
            this._lbTrangThai.Name = "_lbTrangThai";
            this._lbTrangThai.Size = new System.Drawing.Size(0, 19);
            // 
            // timer_TakePicss
            // 
            this.timer_TakePicss.Tick += new System.EventHandler(this.timer_TakePicss_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(533, 158);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(741, 411);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Command);
            this.Controls.Add(this.Stat);
            this.Controls.Add(this.control);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LTTQ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LTTQ_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.control.ResumeLayout(false);
            this.control.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpaceBar)).EndInit();
            this.TimeBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TimeBar)).EndInit();
            this.Stat.ResumeLayout(false);
            this.Stat.PerformLayout();
            this.Command.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel control;
        private System.Windows.Forms.Label Input_txt3;
        private System.Windows.Forms.Label Input_txt2;
        private System.Windows.Forms.Label Input_txt1;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Panel Stat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox TypeBox;
        private System.Windows.Forms.GroupBox TimeBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar TimeBar;
        private System.Windows.Forms.TrackBar SpaceBar;
        private System.Windows.Forms.Label SpaceLabel;
        private System.Windows.Forms.Panel Command;
        private System.Windows.Forms.RadioButton Start;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button _btnTakePic;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel _lbTrangThai;
        private System.Windows.Forms.Button _btnTakePicss;
        private System.Windows.Forms.Timer timer_TakePicss;
        private System.Windows.Forms.CheckBox _chboxXemHinh;
        private System.Windows.Forms.Timer timer1;
    }
}

