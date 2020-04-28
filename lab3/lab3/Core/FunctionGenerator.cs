using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Core
{
    public class FunctionGenerator
    {
        public double[] Generate(double from, double to, double dt)
        {
            var result = new List<double>();
            for (double i = from; i <= to; i += dt)
            {
                result.Add(Function(i));
            }
            return result.ToArray();
        }

        private double Function(double t)
        {
            const double omega = 2 * Math.PI;
            return Math.Sin(t * omega / 10 + 1) + Math.Sin(t * omega / 40 + Math.PI / 2);
        }
    }
}