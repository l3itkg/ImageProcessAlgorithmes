using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Interfaces;

namespace Plugins.MedianFilter
{
    public class MedianFilterParameter : AbstractParameter
    {
        public int Radius { get; set; }
        public override void Configure()
        {
            using (var form = new MedianFilterParameterForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Radius = form.Radius;
                }
            }

        }
    }
}
