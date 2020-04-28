using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plugins.Scale
{
    public partial class ScaleParameterForm : Form
    {
        public double GetScale => tbScale.Value / 10.0;

        public ScaleParameterForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbScale_Scroll(object sender, EventArgs e)
        {
            if (sender is TrackBar tb) lblScale.Text = $"Scale: {tb.Value / 10.0}";
        }
    }
}