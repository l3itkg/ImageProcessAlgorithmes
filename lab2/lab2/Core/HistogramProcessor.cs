using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab2.Core.Models;

namespace lab2.Core
{
    public class HistogramProcessor
    {
        public Histogram GetLocalMins(Histogram histogram)
        {
            return new Histogram(GetMins(histogram.ValuesR).ToArray(),
                GetMins(histogram.ValuesG).ToArray(),
                GetMins(histogram.ValuesB).ToArray());
        }

        private IEnumerable<int> GetMins(int[] values)
        {
            for (var i = 1; i < values.Length - 1; i++)
                if (values[i] < values[i - 1] && values[i] < values[i + 1])
                    yield return i;
            yield return 255;
        }
    }
}
