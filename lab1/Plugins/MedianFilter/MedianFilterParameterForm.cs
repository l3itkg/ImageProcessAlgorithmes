using System;
using System.Windows.Forms;

namespace Plugins.MedianFilter
{
    public partial class MedianFilterParameterForm : Form
    {
        public int Radius => tbRadius.Value;

        public MedianFilterParameterForm()
        {
            InitializeComponent();
            AcceptButton = btnSubmit;
            btnSubmit.DialogResult = DialogResult.OK;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbRadius_Scroll(object sender, EventArgs e)
        {
            if (sender is TrackBar tb) lblRadius.Text = $"Radius:{tb.Value}";
        }
    }
}