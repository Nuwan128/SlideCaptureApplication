namespace SlideCapture
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnStart = new Button();
            btnStop = new Button();
            btnGeneratePDF = new Button();
            pictureBox1 = new PictureBox();
            btnMinimize = new Button();
            btnClose = new Button();
            SlideCountLabel = new Label();
            TimeLabel = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.Transparent;
            btnStart.BackgroundImage = (Image)resources.GetObject("btnStart.BackgroundImage");
            btnStart.BackgroundImageLayout = ImageLayout.Zoom;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.ForeColor = Color.Transparent;
            btnStart.Location = new Point(97, 18);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(60, 30);
            btnStart.TabIndex = 1;
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.Transparent;
            btnStop.BackgroundImage = (Image)resources.GetObject("btnStop.BackgroundImage");
            btnStop.BackgroundImageLayout = ImageLayout.Zoom;
            btnStop.FlatAppearance.BorderSize = 0;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.Location = new Point(167, 18);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(60, 30);
            btnStop.TabIndex = 2;
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // btnGeneratePDF
            // 
            btnGeneratePDF.BackColor = Color.Transparent;
            btnGeneratePDF.BackgroundImage = (Image)resources.GetObject("btnGeneratePDF.BackgroundImage");
            btnGeneratePDF.BackgroundImageLayout = ImageLayout.Zoom;
            btnGeneratePDF.FlatAppearance.BorderSize = 0;
            btnGeneratePDF.FlatStyle = FlatStyle.Flat;
            btnGeneratePDF.Location = new Point(237, 18);
            btnGeneratePDF.Name = "btnGeneratePDF";
            btnGeneratePDF.Size = new Size(60, 30);
            btnGeneratePDF.TabIndex = 3;
            btnGeneratePDF.UseVisualStyleBackColor = false;
            btnGeneratePDF.Click += btnGeneratePDF_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(86, 64);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // btnMinimize
            // 
            btnMinimize.BackColor = Color.Transparent;
            btnMinimize.BackgroundImage = (Image)resources.GetObject("btnMinimize.BackgroundImage");
            btnMinimize.BackgroundImageLayout = ImageLayout.Zoom;
            btnMinimize.Cursor = Cursors.Hand;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.ForeColor = Color.Transparent;
            btnMinimize.Location = new Point(373, -3);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(58, 29);
            btnMinimize.TabIndex = 4;
            btnMinimize.UseVisualStyleBackColor = true;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.BackgroundImage = (Image)resources.GetObject("btnClose.BackgroundImage");
            btnClose.BackgroundImageLayout = ImageLayout.Zoom;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.Transparent;
            btnClose.Location = new Point(437, -3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(58, 29);
            btnClose.TabIndex = 5;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // SlideCountLabel
            // 
            SlideCountLabel.AutoSize = true;
            SlideCountLabel.BackColor = Color.Transparent;
            SlideCountLabel.ForeColor = Color.FromArgb(143, 40, 198);
            SlideCountLabel.Location = new Point(300, 33);
            SlideCountLabel.Name = "SlideCountLabel";
            SlideCountLabel.Size = new Size(134, 20);
            SlideCountLabel.TabIndex = 3;
            SlideCountLabel.Text = "Slide Captured : 00";
            // 
            // TimeLabel
            // 
            TimeLabel.AutoSize = true;
            TimeLabel.BackColor = Color.Transparent;
            TimeLabel.ForeColor = Color.FromArgb(143, 40, 198);
            TimeLabel.Location = new Point(451, 33);
            TimeLabel.Name = "TimeLabel";
            TimeLabel.Size = new Size(44, 20);
            TimeLabel.TabIndex = 3;
            TimeLabel.Text = "00:00";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.FromArgb(143, 40, 198);
            label2.Location = new Point(435, 33);
            label2.Name = "label2";
            label2.Size = new Size(15, 20);
            label2.TabIndex = 3;
            label2.Text = "/";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(510, 64);
            ControlBox = false;
            Controls.Add(label2);
            Controls.Add(TimeLabel);
            Controls.Add(SlideCountLabel);
            Controls.Add(btnClose);
            Controls.Add(btnMinimize);
            Controls.Add(pictureBox1);
            Controls.Add(btnGeneratePDF);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SlideCapture_V1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private Button btnGeneratePDF;
        private PictureBox pictureBox1;
        private Button btnMinimize;
        private Button btnClose;
        private Label SlideCountLabel;
        private Label TimeLabel;
        private Label label2;
    }
}