using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Interfaces;

namespace Plugins.Rotation
{
    public class RotationParameter : AbstractParameter
    {
        public double Angle { get; set; }
        public override void Configure()
        {
            using (var form = new RotationParameterForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Angle = form.Angle;
                }
            }
        }
    }
}
