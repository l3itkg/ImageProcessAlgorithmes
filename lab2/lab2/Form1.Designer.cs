namespace lab2
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.chkHighlight = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSegmentate = new System.Windows.Forms.Button();
            this.btnSmoothGist = new System.Windows.Forms.Button();
            this.btnGist = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pbMain);
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(847, 415);
            this.panel1.TabIndex = 10;
            // 
            // pbMain
            // 
            this.pbMain.Location = new System.Drawing.Point(4, 4);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(327, 212);
            this.pbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 11);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 9;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // chkHighlight
            // 
            this.chkHighlight.AutoSize = true;
            this.chkHighlight.Location = new System.Drawing.Point(744, 13);
            this.chkHighlight.Name = "chkHighlight";
            this.chkHighlight.Size = new System.Drawing.Size(115, 17);
            this.chkHighlight.TabIndex = 17;
            this.chkHighlight.Text = "Highlight segments";
            this.chkHighlight.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(583, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Treshold";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(637, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(440, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Dynamically segment";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSegmentate
            // 
            this.btnSegmentate.Location = new System.Drawing.Point(358, 11);
            this.btnSegmentate.Name = "btnSegmentate";
            this.btnSegmentate.Size = new System.Drawing.Size(75, 23);
            this.btnSegmentate.TabIndex = 13;
            this.btnSegmentate.Text = "Segment";
            this.btnSegmentate.UseVisualStyleBackColor = true;
            this.btnSegmentate.Click += new System.EventHandler(this.btnSegmentate_Click);
            // 
            // btnSmoothGist
            // 
            this.btnSmoothGist.Location = new System.Drawing.Point(201, 11);
            this.btnSmoothGist.Name = "btnSmoothGist";
            this.btnSmoothGist.Size = new System.Drawing.Size(150, 23);
            this.btnSmoothGist.TabIndex = 12;
            this.btnSmoothGist.Text = "Show smooth histogram";
            this.btnSmoothGist.UseVisualStyleBackColor = true;
            this.btnSmoothGist.Click += new System.EventHandler(this.btnSmoothGist_Click);
            // 
            // btnGist
            // 
            this.btnGist.Location = new System.Drawing.Point(93, 11);
            this.btnGist.Name = "btnGist";
            this.btnGist.Size = new System.Drawing.Size(102, 23);
            this.btnGist.TabIndex = 11;
            this.btnGist.Text = "Show histogram";
            this.btnGist.UseVisualStyleBackColor = true;
            this.btnGist.Click += new System.EventHandler(this.btnGist_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 485);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.chkHighlight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSegmentate);
            this.Controls.Add(this.btnSmoothGist);
            this.Controls.Add(this.btnGist);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.CheckBox chkHighlight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSegmentate;
        private System.Windows.Forms.Button btnSmoothGist;
        private System.Windows.Forms.Button btnGist;
    }
}

