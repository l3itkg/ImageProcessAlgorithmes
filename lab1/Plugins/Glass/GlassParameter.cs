using System.Windows.Forms;
using Common.Interfaces;

namespace Plugins.Glass
{
    class GlassParameter : AbstractParameter
    {
        public int Radius { get; set; }

        public override void Configure()
        {
            using (var form = new GlassParameterForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Radius = form.GetRadius;
                }
            }
        }
    }
}