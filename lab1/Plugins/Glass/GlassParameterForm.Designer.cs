namespace Plugins.Glass
{
    partial class GlassParameterForm
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
            this.lblSigma = new System.Windows.Forms.Label();
            this.tbSigma = new System.Windows.Forms.TrackBar();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSigma)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.62069F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.37931F));
            this.tableLayoutPanel1.Controls.Add(this.lblSigma, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbSigma, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSubmit, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.75862F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.24138F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(290, 116);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblSigma
            // 
            this.lblSigma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSigma.AutoSize = true;
            this.lblSigma.Location = new System.Drawing.Point(13, 27);
            this.lblSigma.Name = "lblSigma";
            this.lblSigma.Size = new System.Drawing.Size(55, 13);
            this.lblSigma.TabIndex = 0;
            this.lblSigma.Text = "Radius: 1 ";
            // 
            // tbSigma
            // 
            this.tbSigma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbSigma.Location = new System.Drawing.Point(108, 11);
            this.tbSigma.Minimum = 1;
            this.tbSigma.Name = "tbSigma";
            this.tbSigma.Size = new System.Drawing.Size(156, 45);
            this.tbSigma.TabIndex = 1;
            this.tbSigma.Value = 1;
            this.tbSigma.Scroll += new System.EventHandler(this.tbSigma_Scroll);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.btnSubmit, 2);
            this.btnSubmit.Location = new System.Drawing.Point(107, 80);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Ok";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // GlassParameterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 159);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GlassParameterForm";
            this.Text = "GlassParameterForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSigma)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblSigma;
        private System.Windows.Forms.TrackBar tbSigma;
        private System.Windows.Forms.Button btnSubmit;
    }
}