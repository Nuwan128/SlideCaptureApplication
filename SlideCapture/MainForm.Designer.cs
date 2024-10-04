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
            btnStart = new Button();
            btnStop = new Button();
            btnGeneratePDF = new Button();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(71, 93);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(150, 29);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start Capture";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(239, 93);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(150, 29);
            btnStop.TabIndex = 0;
            btnStop.Text = "Stop Capture";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnGeneratePDF
            // 
            btnGeneratePDF.Location = new Point(424, 93);
            btnGeneratePDF.Name = "btnGeneratePDF";
            btnGeneratePDF.Size = new Size(150, 29);
            btnGeneratePDF.TabIndex = 0;
            btnGeneratePDF.Text = "Generate PDF ";
            btnGeneratePDF.UseVisualStyleBackColor = true;
            btnGeneratePDF.Click += btnGeneratePDF_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGeneratePDF);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private Button btnGeneratePDF;
    }
}