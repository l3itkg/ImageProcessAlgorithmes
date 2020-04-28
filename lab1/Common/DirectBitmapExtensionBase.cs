using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Common
{
    public static class DirectBitmapExtensionBase
    {
        public static Color BilinearInterpolaton(this IDirectBitmap bitmat, double x, double y)
        {
            var xFloor = (int) Math.Floor(x);
            var yFloor = (int) Math.Floor(y);
            var xCeil = (int) Math.Ceiling(x);
            var yCeil = (int) Math.Ceiling(y);

            var dx = x - xFloor;
            var dy = y - yFloor;

            var topLeft = bitmat.GetPixel(NormalizeBounds(xFloor, 0, bitmat.Width),
                NormalizeBounds(yFloor, 0, bitmat.Height));
            var topRight = bitmat.GetPixel(NormalizeBounds(xCeil, 0, bitmat.Width),
                NormalizeBounds(yFloor, 0, bitmat.Height));
            var bottomLeft = bitmat.GetPixel(NormalizeBounds(xFloor, 0, bitmat.Width),
                NormalizeBounds(yCeil, 0, bitmat.Height));
            var bottomRight = bitmat.GetPixel(NormalizeBounds(xCeil, 0, bitmat.Width),
                NormalizeBounds(yCeil, 0, bitmat.Height));

            var topRed = (1 - dx) * topLeft.R + dx * topRight.R;
            var topGreen = (1 - dx) * topLeft.G + dx * topRight.G;
            var topBlue = (1 - dx) * topLeft.B + dx * topRight.B;

            var bottomRed = (1 - dx) * bottomLeft.R + dx * bottomRight.R;
            var bottomGreen = (1 - dx) * bottomLeft.G + dx * bottomRight.G;
            var bottomBlue = (1 - dx) * bottomLeft.B + dx * bottomRight.B;

            var r = (1 - dy) * topRed + dy * bottomRed;
            var g = (1 - dy) * topGreen + dy * bottomGreen;
            var b = (1 - dy) * topBlue + dy * bottomBlue;
            return Color.FromArgb(ColorRange((int) r), ColorRange((int) g), ColorRange((int) b));
        }

        public static int ColorRange(int c)
        {
            return c < 0 ? 0 : c > 255 ? 255 : c;
        }

        public static int NormalizeBounds(int value, int a, int b)
        {
            return value < a ? a : value >= b ? b - 1 : value;
        }

        public static void ApplyConvolutionFilter(IDirectBitmap bitmap, Kernel ker)
        {
            using (var original = (IDirectBitmap) bitmap.Clone())
            {
                Parallel.ForEach(Enumerable.Range(0, bitmap.Height),
                    new ParallelOptions {MaxDegreeOfParallelism = Environment.ProcessorCount}, y =>
                    {
                        for (var x = 0; x < bitmap.Width; x++)
                        {
                            var rsum = 0.0;
                            var gsum = 0.0;
                            var bsum = 0.0;
                            for (var l = 0; l < ker.Width; l++)
                            {
                                for (var k = 0; k < ker.Height; k++)
                                {
                                    var n = NormalizeBounds(x - (l - ker.Width / 2), 0, bitmap.Width);
                                    var m = NormalizeBounds(y - (k - ker.Height / 2), 0, bitmap.Height);
                                    var p = original.GetPixel(n, m);
                                    rsum += ker.Get(k, l) * p.R;
                                    gsum += ker.Get(k, l) * p.G;
                                    bsum += ker.Get(k, l) * p.B;
                                }
                            }

                            var r = ColorRange((int) rsum);
                            var g = ColorRange((int) gsum);
                            var b = ColorRange((int) bsum);
                            bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
                        }
                    });
            }
        }

        public static void ApplyConvolutionFilter(IDirectBitmap bitmap, Kernel kerX, Kernel kerY)
        {
            using (var original = (IDirectBitmap) bitmap.Clone())
            {
                Parallel.ForEach(Enumerable.Range(0, bitmap.Height),
                    new ParallelOptions {MaxDegreeOfParallelism = Environment.ProcessorCount}, y =>
                    {
                        for (var x = 0; x < bitmap.Width; x++)
                        {
                            double rx = 0.0, gx = 0.0, bx = 0.0;
                            double ry = 0.0, gy = 0.0, by = 0.0;

                            for (var l = 0; l < kerX.Width; l++)
                            {
                                for (var k = 0; k < kerX.Height; k++)
                                {
                                    var n = NormalizeBounds(x - (l - kerX.Width / 2), 0, bitmap.Width);
                                    var m = NormalizeBounds(y - (k - kerX.Height / 2), 0, bitmap.Height);
                                    if (original != null)
                                    {
                                        var p = original.GetPixel(n, m);
                                        rx += kerX.Get(k, l) * p.R;
                                        bx += kerX.Get(k, l) * p.G;
                                        gx += kerX.Get(k, l) * p.B;
                                        ry += kerY.Get(k, l) * p.R;
                                        @by += kerY.Get(k, l) * p.G;
                                        gy += kerY.Get(k, l) * p.B;
                                    }
                                }
                            }

                            var bsum = Math.Sqrt(bx * bx + @by * @by);
                            var gsum = Math.Sqrt(gx * gx + gy * gy);
                            var rsum = Math.Sqrt(rx * rx + ry * ry);



                            var r = ColorRange((int) rsum);
                            var g = ColorRange((int) gsum);
                            var b = ColorRange((int) bsum);
                            bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
                        }
                    });
            }
        }
    }
}