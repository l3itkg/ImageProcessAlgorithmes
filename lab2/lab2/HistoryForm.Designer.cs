namespace lab2
{
    partial class HistoryForm
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
            this.bHist = new ZedGraph.ZedGraphControl();
            this.gHist = new ZedGraph.ZedGraphControl();
            this.rHist = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // bHist
            // 
            this.bHist.Location = new System.Drawing.Point(940, 28);
            this.bHist.Name = "bHist";
            this.bHist.ScrollGrace = 0D;
            this.bHist.ScrollMaxX = 0D;
            this.bHist.ScrollMaxY = 0D;
            this.bHist.ScrollMaxY2 = 0D;
            this.bHist.ScrollMinX = 0D;
            this.bHist.ScrollMinY = 0D;
            this.bHist.ScrollMinY2 = 0D;
            this.bHist.Size = new System.Drawing.Size(407, 373);
            this.bHist.TabIndex = 5;
            this.bHist.UseExtendedPrintDialog = true;
            // 
            // gHist
            // 
            this.gHist.Location = new System.Drawing.Point(488, 28);
            this.gHist.Name = "gHist";
            this.gHist.ScrollGrace = 0D;
            this.gHist.ScrollMaxX = 0D;
            this.gHist.ScrollMaxY = 0D;
            this.gHist.ScrollMaxY2 = 0D;
            this.gHist.ScrollMinX = 0D;
            this.gHist.ScrollMinY = 0D;
            this.gHist.ScrollMinY2 = 0D;
            this.gHist.Size = new System.Drawing.Size(434, 373);
            this.gHist.TabIndex = 4;
            this.gHist.UseExtendedPrintDialog = true;
            // 
            // rHist
            // 
            this.rHist.Location = new System.Drawing.Point(17, 28);
            this.rHist.Name = "rHist";
            this.rHist.ScrollGrace = 0D;
            this.rHist.ScrollMaxX = 0D;
            this.rHist.ScrollMaxY = 0D;
            this.rHist.ScrollMaxY2 = 0D;
            this.rHist.ScrollMinX = 0D;
            this.rHist.ScrollMinY = 0D;
            this.rHist.ScrollMinY2 = 0D;
            this.rHist.Size = new System.Drawing.Size(449, 373);
            this.rHist.TabIndex = 3;
            this.rHist.UseExtendedPrintDialog = true;
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 562);
            this.Controls.Add(this.bHist);
            this.Controls.Add(this.gHist);
            this.Controls.Add(this.rHist);
            this.Name = "HistoryForm";
            this.Text = "HistoryForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl bHist;
        private ZedGraph.ZedGraphControl gHist;
        private ZedGraph.ZedGraphControl rHist;
    }
}