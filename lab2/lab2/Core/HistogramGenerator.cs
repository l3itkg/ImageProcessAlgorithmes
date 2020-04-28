using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab2.Core.Models;

namespace lab2.Core
{
    public class HistogramGenerator
    {
        public Histogram Generate(DirectBitmap image)
        {
            var histogram = new Histogram();
            for (var i = 0; i < image.Height; i++)
            for (var j = 0; j < image.Width; j++)
            {
                var pixel = image.GetPixel(i, j);
                histogram.ValuesR[pixel.R]++;
                histogram.ValuesG[pixel.G]++;
                histogram.ValuesB[pixel.B]++;
            }
            return histogram;
        }

        public Histogram Smooth(Histogram histogram, int n)
        {
            return new Histogram(Smooth(histogram.ValuesR, n), Smooth(histogram.ValuesG, n),
                Smooth(histogram.ValuesB, n));
        }

        public Histogram GenerateSmoothed(DirectBitmap image)
        {
            return Smooth(Generate(image), 40);
        }

        private int[] Smooth(int[] values, int n)
        {
            var result = new int[values.Length];
            for (var i = 0; i < values.Length; i++)
            {
                var s = 0;
                for (var j = -n / 2; j <= n / 2; j++)
                {
                    var index = i + j;
                    if (index >= 0 && index < values.Length)
                        s += values[index];
                }
                result[i] = s / n;
            }
            return result;
        }
    }
}
