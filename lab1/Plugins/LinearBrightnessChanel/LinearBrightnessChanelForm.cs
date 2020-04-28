using System;
using System.Windows.Forms;

namespace Plugins.LinearBrightnessChanel
{
    public partial class LinearBrightnessChanelForm : Form
    {
        public int Percentage => tbPercentage.Value;

        public LinearBrightnessChanelForm()
        {
            InitializeComponent();
            btnSubmit.DialogResult = DialogResult.OK;
            AcceptButton = btnSubmit;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
