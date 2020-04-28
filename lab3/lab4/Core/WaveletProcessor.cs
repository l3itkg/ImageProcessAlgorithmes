using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace lab4.Core
{
    public class WaveletProcessor
    {
        private readonly FftProcessor _fftProcessor;
        public WaveletProcessor()
        {
            _fftProcessor = new FftProcessor();
        }

        public double[][] Process(double[] input, int from = 1, int to = 250, int step = 1, double dt = 1)
        {
            var n = input.Length;
            var w0 = 5;
            var result = new List<double[]>();
            var hatX = _fftProcessor.ProcessWORecursion(input.Select(x => new Complex(x, 0)).ToArray());
            var omega = Enumerable.Range(0, n).Select(x =>
                (x < n / 2
                    ? 1
                    : -1) *
                2 * Math.PI * x / n / dt

            ).ToArray();
            var flw = 4 * Math.PI / (w0 + Math.Sqrt(2 + Math.Pow(w0, 2)));
            var scales = Enumerable.Range(1, to - from + 1).Select(x => x / flw).ToArray();

            for (var index = 0; index < scales.Length; index++)
            {
                var scale = scales[index];
                var sOmega = omega.Select(x => x * scale).ToArray();
                var psiHat = HMorlet(sOmega, w0);
                var convHat = psiHat.Select((x, i) => x * hatX[i]).ToArray();
                result.Add(_fftProcessor.ProcessWORecursion(convHat, true).Select(x => (x / n)).Select(x => Math.Sqrt(x.Real * x.Real + x.Imaginary * x.Imaginary)).ToArray());
            }


            return result.ToArray();
        }

        public double[] HMorlet(double[] sOmega, double w0 = 5)
        {
            var pi14 = 0.75112554;
            return sOmega.Select(x => x < 0 ? 0 : pi14 * Math.Exp(-Math.Pow(x - w0, 2) / 2)).ToArray();
        }
    }
}
