namespace lab3
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
            this.components = new System.ComponentModel.Container();
            this.btnFFTwoRec = new System.Windows.Forms.Button();
            this.btnFFT = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDt = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.btnDFT = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.functionChart = new ZedGraph.ZedGraphControl();
            this.fourierChartP = new ZedGraph.ZedGraphControl();
            this.fourierChartA = new ZedGraph.ZedGraphControl();
            this.btnFFTRev = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFFTwoRec
            // 
            this.btnFFTwoRec.Location = new System.Drawing.Point(629, 17);
            this.btnFFTwoRec.Name = "btnFFTwoRec";
            this.btnFFTwoRec.Size = new System.Drawing.Size(118, 23);
            this.btnFFTwoRec.TabIndex = 21;
            this.btnFFTwoRec.Text = "FFT w\\o recursion";
            this.btnFFTwoRec.UseVisualStyleBackColor = true;
            this.btnFFTwoRec.Click += new System.EventHandler(this.btnFFTwoRec_Click);
            // 
            // btnFFT
            // 
            this.btnFFT.Location = new System.Drawing.Point(548, 17);
            this.btnFFT.Name = "btnFFT";
            this.btnFFT.Size = new System.Drawing.Size(75, 23);
            this.btnFFT.TabIndex = 20;
            this.btnFFT.Text = "FFT";
            this.btnFFT.UseVisualStyleBackColor = true;
            this.btnFFT.Click += new System.EventHandler(this.btnFFT_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(402, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Dt";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "To";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "From";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtDt
            // 
            this.txtDt.Location = new System.Drawing.Point(426, 16);
            this.txtDt.Name = "txtDt";
            this.txtDt.Size = new System.Drawing.Size(100, 20);
            this.txtDt.TabIndex = 16;
            this.txtDt.Text = "0.7";
            this.txtDt.TextChanged += new System.EventHandler(this.txtDt_TextChanged);
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(283, 17);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(100, 20);
            this.txtTo.TabIndex = 15;
            this.txtTo.Text = "480";
            this.txtTo.TextChanged += new System.EventHandler(this.txtTo_TextChanged);
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(134, 17);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(100, 20);
            this.txtFrom.TabIndex = 14;
            this.txtFrom.Text = "0";
            this.txtFrom.TextChanged += new System.EventHandler(this.txtFrom_TextChanged);
            // 
            // btnDFT
            // 
            this.btnDFT.Location = new System.Drawing.Point(11, 17);
            this.btnDFT.Name = "btnDFT";
            this.btnDFT.Size = new System.Drawing.Size(75, 23);
            this.btnDFT.TabIndex = 13;
            this.btnDFT.Text = "DFT";
            this.btnDFT.UseVisualStyleBackColor = true;
            this.btnDFT.Click += new System.EventHandler(this.btnDFT_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.functionChart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.fourierChartP, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.fourierChartA, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnFFTRev, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 48);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.48276F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.48276F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.03449F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(785, 386);
            this.tableLayoutPanel1.TabIndex = 12;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // functionChart
            // 
            this.functionChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.functionChart.Location = new System.Drawing.Point(3, 3);
            this.functionChart.Name = "functionChart";
            this.functionChart.ScrollGrace = 0D;
            this.functionChart.ScrollMaxX = 0D;
            this.functionChart.ScrollMaxY = 0D;
            this.functionChart.ScrollMaxY2 = 0D;
            this.functionChart.ScrollMinX = 0D;
            this.functionChart.ScrollMinY = 0D;
            this.functionChart.ScrollMinY2 = 0D;
            this.functionChart.Size = new System.Drawing.Size(779, 113);
            this.functionChart.TabIndex = 0;
            this.functionChart.UseExtendedPrintDialog = true;
            // 
            // fourierChartP
            // 
            this.fourierChartP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fourierChartP.Location = new System.Drawing.Point(3, 281);
            this.fourierChartP.Name = "fourierChartP";
            this.fourierChartP.ScrollGrace = 0D;
            this.fourierChartP.ScrollMaxX = 0D;
            this.fourierChartP.ScrollMaxY = 0D;
            this.fourierChartP.ScrollMaxY2 = 0D;
            this.fourierChartP.ScrollMinX = 0D;
            this.fourierChartP.ScrollMinY = 0D;
            this.fourierChartP.ScrollMinY2 = 0D;
            this.fourierChartP.Size = new System.Drawing.Size(779, 102);
            this.fourierChartP.TabIndex = 2;
            this.fourierChartP.UseExtendedPrintDialog = true;
            // 
            // fourierChartA
            // 
            this.fourierChartA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fourierChartA.Location = new System.Drawing.Point(3, 162);
            this.fourierChartA.Name = "fourierChartA";
            this.fourierChartA.ScrollGrace = 0D;
            this.fourierChartA.ScrollMaxX = 0D;
            this.fourierChartA.ScrollMaxY = 0D;
            this.fourierChartA.ScrollMaxY2 = 0D;
            this.fourierChartA.ScrollMinX = 0D;
            this.fourierChartA.ScrollMinY = 0D;
            this.fourierChartA.ScrollMinY2 = 0D;
            this.fourierChartA.Size = new System.Drawing.Size(779, 113);
            this.fourierChartA.TabIndex = 1;
            this.fourierChartA.UseExtendedPrintDialog = true;
            // 
            // btnFFTRev
            // 
            this.btnFFTRev.Location = new System.Drawing.Point(3, 122);
            this.btnFFTRev.Name = "btnFFTRev";
            this.btnFFTRev.Size = new System.Drawing.Size(75, 23);
            this.btnFFTRev.TabIndex = 3;
            this.btnFFTRev.Text = "FFT reverse";
            this.btnFFTRev.UseVisualStyleBackColor = true;
            this.btnFFTRev.Click += new System.EventHandler(this.btnFFTRev_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFFTwoRec);
            this.Controls.Add(this.btnFFT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDt);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.btnDFT);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFFTwoRec;
        private System.Windows.Forms.Button btnFFT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDt;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Button btnDFT;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ZedGraph.ZedGraphControl functionChart;
        private ZedGraph.ZedGraphControl fourierChartP;
        private ZedGraph.ZedGraphControl fourierChartA;
        private System.Windows.Forms.Button btnFFTRev;
    }
}

