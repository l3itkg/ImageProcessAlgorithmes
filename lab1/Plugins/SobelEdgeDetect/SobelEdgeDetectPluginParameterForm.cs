using System;
using System.Windows.Forms;

namespace Plugins.SobelEdgeDetect
{
    public partial class SobelEdgeDetectPluginParameterForm : Form
    {
        public double GetSigma => tbSigma.Value;

        public SobelEdgeDetectPluginParameterForm()
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
            if (sender is TrackBar tb) lblSigma.Text = $"Scale: {tb.Value / 10.0}";
        }
    }
}
