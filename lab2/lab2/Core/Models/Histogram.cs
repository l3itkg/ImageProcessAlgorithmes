using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Core.Models
{
    public class Histogram
    {
        public Histogram()
        {
            ValuesR = new int[256];
            ValuesG = new int[256];
            ValuesB = new int[256];
        }

        public Histogram(int[] r, int[] g, int[] b)
        {
            ValuesR = r;
            ValuesG = g;
            ValuesB = b;
        }

        public int[] ValuesR { get; set; }
        public int[] ValuesG { get; set; }
        public int[] ValuesB { get; set; }

    }
}