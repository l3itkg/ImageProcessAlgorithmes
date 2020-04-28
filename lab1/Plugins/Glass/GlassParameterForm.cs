using System;
using System.Windows.Forms;

namespace Plugins.Glass
{
    public partial class GlassParameterForm : Form
    {
        public int GetRadius => tbSigma.Value;

        public GlassParameterForm()
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
            if (sender is TrackBar tb) lblSigma.Text = $"Radius: {tb.Value}";
        }
    }
}