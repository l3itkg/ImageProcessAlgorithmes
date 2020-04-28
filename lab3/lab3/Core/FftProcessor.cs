using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Core
{
    public class FftProcessor
    {
        public Complex[] Process(Complex[] values, bool inverse = false)
        {
            var n = values.Length;
            var result = new Complex[values.Length];
            if (n % 2 != 0)
                throw new ArgumentException("Values count shold be degree of 2");
            if (n == 2)
                return new[] { (values[0] + values[1]) / (inverse ? n : 1), (values[0] - values[1]) / (inverse ? n : 1) };

            var x1 = values.Select((x, i) => new { x, i }).Where(x => x.i % 2 == 0).Select(x => x.x).ToArray();
            var x2 = values.Select((x, i) => new { x, i }).Where(x => x.i % 2 != 0).Select(x => x.x).ToArray();

            var values1 = Process(x1, inverse);
            var values2 = Process(x2, inverse);

            for (var k = 0; k < n / 2; k++)
            {
                var tmp = W(inverse ? -k : k, n) * values2[k];
                result[k] = (values1[k] + tmp) / (inverse ? 2 : 1);
                result[k + n / 2] = (values1[k] - tmp) / (inverse ? 2 : 1);
            }
            return result;
        }

        private Complex W(int k, int N, int n = 1)
        {
            var omega = -2 * Math.PI / N * k * n;
            return new Complex(Math.Cos(omega), Math.Sin(omega));
        }

        private int ReverseBits(int n, int log)
        {
            var res = 0;
            for (var i = 0; i < log; ++i)
                if ((n & (1 << i)) > 0)
                    res |= 1 << (log - 1 - i);
            return res;
        }


        public Complex[] ProcessWORecursion(Complex[] values, bool inverse = false)
        {
            var n = values.Length;
            var log = (int)Math.Ceiling(Math.Log(n, 2));

            for (var i = 0; i < n; i++)
            {
                var newIndex = ReverseBits(i, log);
                if (i < newIndex)
                {
                    var tmp = values[i];
                    values[i] = values[newIndex];
                    values[newIndex] = tmp;
                }
            }

            for (var lenght = 2; lenght <= n; lenght *= 2)
                for (var i = 0; i < n; i += lenght)
                    for (var j = 0; j < lenght / 2; j++)
                    {
                        var w = W(inverse ? -j : j, lenght);
                        var u = values[i + j];
                        var v = values[i + j + lenght / 2] * w;
                        values[i + j] = (u + v) / (inverse ? 2 : 1);
                        values[i + j + lenght / 2] = (u - v) / (inverse ? 2 : 1);
                    }
            return values;
        }
    }
}
