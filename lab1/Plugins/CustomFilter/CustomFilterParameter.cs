using System.Windows.Forms;
using Common.Interfaces;

namespace Plugins.CustomFilter
{
    public class CustomFilterParameter : AbstractParameter
    {
        public double[,] Matrix { get; set; }

        public override void Configure()
        {
            using (var form = new CustomFilterParametrForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Matrix = form.Matrix;
                }
            }
        }
    }
}