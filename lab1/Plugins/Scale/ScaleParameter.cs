using System.Windows.Forms;
using Common.Interfaces;

namespace Plugins.Scale
{
    public class ScaleParameter : AbstractParameter
    {
        public double Scale { get; set; }

        public override void Configure()
        {
            using (var form = new ScaleParameterForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Scale = form.GetScale;
                }
            }

        }

    }
}
