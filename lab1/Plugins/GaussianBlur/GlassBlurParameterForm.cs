using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plugins.GaussianBlur
{
    public partial class GlassBlurParameterForm : Form
    {
        public double GetSigma => tbSigma.Value;

        public GlassBlurParameterForm()
        {
            InitializeComponent();
            AcceptButton = btnSubmit;
            btnSubmit.DialogResult = DialogResult.OK;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbSigma_Scroll(object sender, EventArgs e)
        {
            if (sender is TrackBar tb) lblSigma.Text = $"Scale: {tb.Value}";
        }
    }
}
