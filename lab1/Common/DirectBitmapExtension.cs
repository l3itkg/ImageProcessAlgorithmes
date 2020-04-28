using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Common
{
    public static class DirectBitmapExtension
    {
        public static void Process(this IDirectBitmap bitmap)
        {
            for (var i = 0; i < bitmap.Width; i++)
            for (var x = 0; x < bitmap.Height; x++)
            {
                var oc = bitmap.GetPixel(i, x);
                var grayScale = (int) (oc.R * 0.3 + oc.G * 0.59 + oc.B * 0.11);
                var nc = Color.FromArgb(oc.A, grayScale, grayScale, grayScale);
                bitmap.SetPixel(i, x, nc);
            }
        }

        public static void Process(this IDirectBitmap bitmap, double sigma)
        {
            var kerRow = Kernel.GaussRowKernel(sigma);
            var kerCol = Kernel.GaussColumnKernel(sigma);
            DirectBitmapExtensionBase.ApplyConvolutionFilter(bitmap, kerRow);
            DirectBitmapExtensionBase.ApplyConvolutionFilter(bitmap, kerCol);

        }

        public static void Process(this IDirectBitmap bitmap, int radius)
        {
            using (var original = (IDirectBitmap) bitmap.Clone())
            {
                Parallel.ForEach(Enumerable.Range(0, bitmap.Height),
                    new ParallelOptions {MaxDegreeOfParallelism = Environment.ProcessorCount}, y =>
                    {
                        var random = new Random(y);
                        for (var x = 0; x < bitmap.Width; x++)
                        {

                            int x1 =
                                DirectBitmapExtensionBase.NormalizeBounds(
                                    (int) (x + (random.Next(1000) / 1000.0 - 0.5) * radius), 0,
                                    bitmap.Width);
                            int y1 =
                                DirectBitmapExtensionBase.NormalizeBounds(
                                    (int) (y + (random.Next(1000) / 1000.0 - 0.5) * radius), 0,
                                    bitmap.Height);
                            var c = original.GetPixel(x, y);
                            bitmap.SetPixel(x1, y1, c);
                        }
                    });
            }

        }


        private const double RedIntense = 0.2125;
        private const double GreenIntense = 0.7154;
        private const double BlueIntense = 0.0721;

        private static int GetBrightness(Color color)
        {
            return (int)(color.R * RedIntense + color.G * GreenIntense + color.B * BlueIntense);
        }

        public static void ProcessGrayWorld(this IDirectBitmap bitmap)
        {
            double rAvg = 0, gAvg = 0, bAvg = 0;

            var bitCount = bitmap.Width * bitmap.Height;

            for (var x = 0; x < bitmap.Width; x++)
            for (var y = 0; y < bitmap.Height; y++)
            {
                rAvg += bitmap.GetPixel(x, y).R;
                gAvg += bitmap.GetPixel(x, y).G;
                bAvg += bitmap.GetPixel(x, y).B;
            }

            rAvg /= bitCount;
            gAvg /= bitCount;
            bAvg /= bitCount;

            var avg = (rAvg + gAvg + bAvg) / 3;
            Parallel.ForEach(Enumerable.Range(0, bitmap.Height),
                new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
                y =>
                {
                    for (var x = 0; x < bitmap.Width; x++)
                    {
                        var oldColor = bitmap.GetPixel(x, y);
                        var r = ColorRange((int)(oldColor.R * avg / rAvg));
                        var g = ColorRange((int)(oldColor.G * avg / gAvg));
                        var b = ColorRange((int)(oldColor.B * avg / bAvg));
                        bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                });
        }

        private static int ColorRange(int c)
        {
            return c < 0 ? 0 : c > 255 ? 255 : c;
        }


        public static void AdjustBrightness(this IDirectBitmap bitmap)
        {
            byte minR = 255,
                maxR = 0,
                minG = 255,
                maxG = 0,
                minB = 255,
                maxB = 0;

            for (var x = 0; x < bitmap.Width; x++)
            for (var y = 0; y < bitmap.Height; y++)
            {
                var c = bitmap.GetPixel(x, y);
                minR = c.R < minR ? c.R : minR;
                minG = c.G < minG ? c.G : minG;
                minB = c.B < minB ? c.B : minB;

                maxR = c.R > maxR ? c.R : maxR;
                maxG = c.G > maxG ? c.G : maxG;
                maxB = c.B > maxB ? c.B : maxB;
            }

            Parallel.ForEach(Enumerable.Range(0, bitmap.Height),
                new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
                y =>
                {
                    for (var x = 0; x < bitmap.Width; x++)
                    {
                        var oldColor = bitmap.GetPixel(x, y);

                        var newColor = Color.FromArgb(
                            (oldColor.R - minR) * 255 / (maxR - minR),
                            (oldColor.G - minG) * 255 / (maxG - minG),
                            (oldColor.B - minB) * 255 / (maxB - minB));
                        bitmap.SetPixel(x, y, newColor);
                    }
                });
        }


        public static void ProcessMedianFilter(this IDirectBitmap bitmap, int radius)
        {
            var d = 2 * radius + 1;
            var r = d / 2;
            using (var original = (IDirectBitmap)bitmap.Clone())
            {
                Parallel.ForEach(Enumerable.Range(0, bitmap.Height),
                    new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, y =>
                    {
                        var red = new byte[d * d];
                        var green = new byte[d * d];
                        var blue = new byte[d * d];
                        for (var x = 0; x < bitmap.Width; x++)
                        {
                            var p = 0;
                            for (var i = 0; i < d; i++)
                            {
                                for (var j = 0; j < d; j++)
                                {
                                    var xc = NormalizeBounds(x + (i - r), 0, bitmap.Width);
                                    var yc = NormalizeBounds(y + (j - r), 0, bitmap.Height);
                                    var c = original.GetPixel(xc, yc);
                                    red[p] = c.R;
                                    green[p] = c.G;
                                    blue[p] = c.B;
                                    p++;
                                }
                            }

                            var rMed = red.OrderBy(e => e).ElementAt(p / 2);
                            var gMed = green.OrderBy(e => e).ElementAt(p / 2);
                            var bMed = blue.OrderBy(e => e).ElementAt(p / 2);
                            bitmap.SetPixel(x, y, Color.FromArgb(rMed, gMed, bMed));
                        }
                    });
            }
        }

        private static int NormalizeBounds(int value, int a, int b)
        {
            return value < a ? a : value >= b ? b - 1 : value;
        }

        public static void ProcessRotation(this IDirectBitmap bitmap, double angle)
        {
            angle *= -Math.PI / 180.0;
            var cos = Math.Cos(angle);
            var sin = Math.Sin(angle);

            var point1X = (-bitmap.Height * sin);
            var point1Y = (bitmap.Height * cos);
            var point2X = (bitmap.Width * cos - bitmap.Height * sin);
            var point2Y = (bitmap.Height * cos + bitmap.Width * sin);
            var point3X = (bitmap.Width * cos);
            var point3Y = (bitmap.Width * sin);

            var minx = Math.Min(0, Math.Min(point1X, Math.Min(point2X, point3X)));
            var miny = Math.Min(0, Math.Min(point1Y, Math.Min(point2Y, point3Y)));
            var maxx = Math.Max(0, Math.Max(point1X, Math.Max(point2X, point3X)));
            var maxy = Math.Max(0, Math.Max(point1Y, Math.Max(point2Y, point3Y)));

            var destBitmapWidth = (int)Math.Ceiling(Math.Abs(maxx) - minx + 1);
            var destBitmapHeight = (int)Math.Ceiling(Math.Abs(maxy) - miny + 1);

            using (var original = (IDirectBitmap)bitmap.Clone())
            {
                bitmap.Resize(destBitmapWidth, destBitmapHeight);


                Parallel.ForEach(Enumerable.Range(0, bitmap.Height),
                    new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, y =>
                    {
                        for (var x = 0; x < bitmap.Width; x++)
                        {
                            var oldX = ((x + minx) * cos + (y + miny) * sin);
                            var oldY = ((y + miny) * cos - (x + minx) * sin);
                            var checkRange = oldY >= 0 && oldY < original.Height && oldX >= 0 && oldX < original.Width;
                            var c = checkRange ? original.BilinearInterpolaton(oldX, oldY) : Color.FromArgb(0, 0, 0);
                            bitmap.SetPixel(x, y, c);
                        }
                    });
            }
        }

        public static void ProcessScale(this IDirectBitmap bitmap, double scale)
        {
            using (var original = (IDirectBitmap)bitmap.Clone())
            {
                var newWidth = (int)(bitmap.Width * scale);
                var newHeight = (int)(bitmap.Height * scale);
                bitmap.Resize(newWidth, newHeight);
                Parallel.For(0, bitmap.Height - 1,
                    new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
                    y =>
                    {
                        for (var x = 0; x < bitmap.Width; x++)
                        {
                            var oldX = x / scale;
                            var oldY = y / scale;

                            var c = original.BilinearInterpolaton(oldX, oldY);

                            bitmap.SetPixel(x, y, c);
                        }
                    });
            }
        }
    }
}