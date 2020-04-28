
using System.Drawing;
using System.Threading.Tasks;
using lab2.Core.Models;

namespace lab2.Core
{
    public class SegmentationProcessor
    {
        private readonly HistogramGenerator _histogramGenerator;
        private readonly HistogramProcessor _histogramProcessor;

        public SegmentationProcessor()
        {
            _histogramProcessor = new HistogramProcessor();
            _histogramGenerator = new HistogramGenerator();
        }

        public DirectBitmap Segment(DirectBitmap image)
        {
            var histogram = _histogramGenerator.GenerateSmoothed(image);
            var mins = _histogramProcessor.GetLocalMins(histogram);
            return Process(image, mins);
        }

        private DirectBitmap Process(DirectBitmap image, Histogram mins)
        {
            var newImg = (DirectBitmap)image.Clone();

            Parallel.For(0, newImg.Height, i =>
            {
                for (var j = 0; j < newImg.Width; j++)
                {
                    var pixel = newImg.GetPixel(j, i);
                    var r = GetChanelValue(mins.ValuesR, pixel.R);
                    var g = GetChanelValue(mins.ValuesG, pixel.G);
                    var b = GetChanelValue(mins.ValuesB, pixel.B);
                    newImg.SetPixel(j, i, Color.FromArgb(pixel.A, r, g, b));
                }
            });

            return newImg;
        }

        private static int GetChanelValue(int[] mins, int value)
        {
            foreach (var min in mins)
            {
                if (value < min)
                {
                    value = min;
                    break;
                }
            }
            return value;
        }
    }
}
