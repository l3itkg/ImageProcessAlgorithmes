namespace Plugins.Rotation
{
    partial class RotationParameterForm
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
            this.tbAngle = new System.Windows.Forms.TrackBar();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblAngle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tbAngle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSubmit, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAngle, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.37838F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.62162F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(372, 108);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tbAngle
            // 
            this.tbAngle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbAngle.Location = new System.Drawing.Point(204, 6);
            this.tbAngle.Maximum = 359;
            this.tbAngle.Minimum = 1;
            this.tbAngle.Name = "tbAngle";
            this.tbAngle.Size = new System.Drawing.Size(149, 45);
            this.tbAngle.TabIndex = 4;
            this.tbAngle.Value = 1;
            this.tbAngle.Scroll += new System.EventHandler(this.tbAngle_Scroll);
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
            // lblAngle
            // 
            this.lblAngle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAngle.AutoSize = true;
            this.lblAngle.Location = new System.Drawing.Point(74, 22);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new System.Drawing.Size(37, 13);
            this.lblAngle.TabIndex = 1;
            this.lblAngle.Text = "Angle:";
            // 
            // RotationParameterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 137);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RotationParameterForm";
            this.Text = "RotationParameterForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAngle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TrackBar tbAngle;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblAngle;
    }
}