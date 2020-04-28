using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Core
{
    public class DftProcessor
    {
        public Complex[] Transform(double[] values, bool inverse)
        {
            return values.Select((_, k) => Transform(k, values, inverse)).ToArray();
        }

        private Complex Transform(int k, double[] values, bool inverse)
        {
            Complex result = 0;
            var N = values.Length;
            for (var n = 0; n < values.Length; n++)
            {
                var omega = 2 * Math.PI / N * k * n;
                if (!inverse)
                    omega = -omega;

                result += new Complex(Math.Cos(omega) * values[n], 0);
                result += new Complex(0, Math.Sin(omega) * values[n]);
            }
            if (inverse)
                result /= N;
            return result;
        }
    }
}
