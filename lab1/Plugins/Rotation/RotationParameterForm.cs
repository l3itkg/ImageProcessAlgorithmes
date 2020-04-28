using System;
using System.Windows.Forms;

namespace Plugins.Rotation
{
    public partial class RotationParameterForm : Form
    {
        public double Angle => tbAngle.Value;

        public RotationParameterForm()
        {
            InitializeComponent();
            AcceptButton = btnSubmit;
            btnSubmit.DialogResult = DialogResult.OK;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbAngle_Scroll(object sender, EventArgs e)
        {
            if (sender is TrackBar tb) lblAngle.Text = $"Angle:{tb.Value}";
        }
    }
}
