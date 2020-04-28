namespace Plugins.MedianFilter
{
    partial class MedianFilterParameterForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbRadius = new System.Windows.Forms.TrackBar();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblRadius = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbRadius)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tbRadius, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSubmit, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblRadius, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.37838F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.62162F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(372, 108);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tbRadius
            // 
            this.tbRadius.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbRadius.Location = new System.Drawing.Point(204, 6);
            this.tbRadius.Minimum = 1;
            this.tbRadius.Name = "tbRadius";
            this.tbRadius.Size = new System.Drawing.Size(149, 45);
            this.tbRadius.TabIndex = 4;
            this.tbRadius.Value = 1;
            this.tbRadius.Scroll += new System.EventHandler(this.tbRadius_Scroll);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.btnSubmit, 2);
            this.btnSubmit.Location = new System.Drawing.Point(148, 71);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Ok";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblRadius
            // 
            this.lblRadius.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRadius.AutoSize = true;
            this.lblRadius.Location = new System.Drawing.Point(71, 22);
            this.lblRadius.Name = "lblRadius";
            this.lblRadius.Size = new System.Drawing.Size(43, 13);
            this.lblRadius.TabIndex = 1;
            this.lblRadius.Text = "Radius:";
            // 
            // MedianFilterParameterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 144);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MedianFilterParameterForm";
            this.Text = "MedianFilterParameterForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbRadius)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TrackBar tbRadius;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblRadius;
    }
}