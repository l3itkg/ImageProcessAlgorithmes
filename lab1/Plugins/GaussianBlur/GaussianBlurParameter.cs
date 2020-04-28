using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Interfaces;

namespace Plugins.GaussianBlur
{
    class GaussianBlurParameter : AbstractParameter
    {
        public double Sigma { get; set; }


        public override void Configure()
        {
            using (var form = new GlassBlurParameterForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Sigma = form.GetSigma;
                }
            }

        }
    }
}