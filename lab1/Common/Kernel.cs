using System;

namespace Common
{
    public class Kernel
    {
        private readonly double[,] _kernel;

        public Kernel(int n, int m)
        {
            _kernel = new double[n, m];
            Height = n;
            Width = m;
        }

        public Kernel(double[,] kernel)
        {
            _kernel = kernel;
            Height = kernel.GetLength(0);
            Width = kernel.GetLength(1);
        }

        public int Width { get; }
        public int Height { get; }

        public static Kernel Sobel3Horizontal()
        {
            var k = new Kernel(3, 3);
            var s = new double[,]
            {
                {-1, 0, 1},
                {-2, 0, 2},
                {-1, 0, 1}
            };
            for (var i = 0; i < 3; i++)
            for (var j = 0; j < 3; j++)
                k._kernel[i, j] = s[i, j];
            return k;
        }

        public static Kernel Sobel3Vertical()
        {
            var k = new Kernel(3, 3);
            var s = new double[,]
            {
                {1, 2, 1},
                {0, 0, 0},
                {-1, -2, -1}
            };
            for (var i = 0; i < 3; i++)
            for (var j = 0; j < 3; j++)
                k._kernel[i, j] = s[i, j];
            return k;
        }


        public static Kernel GaussKernel(double sigma)
        {
            var size = (int) (6.0 * sigma);
            if (size % 2 == 0)
                size--;

            if (size <= 0)
                return new Kernel(0, 0);


            var k = new Kernel(size, size);

            for (var i = 0; i < k.Height; i++)
            {
                for (var j = 0; j < k.Width; j++)
                {
                    k._kernel[i, j] = Normal(j - size / 2, i - size / 2, sigma);
                }
            }

            k.Normalize();
            return k;
        }

        public static Kernel GaussColumnKernel(double sigma)
        {
            var size = (int) (6.0 * sigma);
            if (size % 2 == 0)
                size--;

            if (size <= 0)
                return new Kernel(0, 0);


            Kernel column = new Kernel(size, 1);

            for (var i = 0; i < size; i++)
            {
                column._kernel[i, 0] = Normal(0, i - size / 2, sigma);


            }

            column.Normalize();
            return column;
        }

        public static Kernel GaussRowKernel(double sigma)
        {
            var size = (int) (6.0 * sigma);
            if (size % 2 == 0)
                size--;

            if (size <= 0)
                return new Kernel(0, 0);


            Kernel row = new Kernel(1, size);

            for (var i = 0; i < size; i++)
            {
                row._kernel[0, i] = Normal(i - size / 2, 0, sigma);


            }

            row.Normalize();
            return row;
        }

        private void Normalize()
        {
            var sum = 0.0;
            int i, j;

            for (i = 0; i < Height; i++)
            {
                for (j = 0; j < Width; j++)
                {
                    sum += _kernel[i, j];
                }
            }

            if (sum < 0.00001)
                return;
            for (i = 0; i < Height; i++)
            {
                for (j = 0; j < Width; j++)
                {
                    _kernel[i, j] /= sum;
                }
            }
        }

        public void Reverse()
        {
            for (int i = 0; i < Height / 2; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    LinqExtension.Swap(ref _kernel[i, j], ref _kernel[Height - i - 1, j]);
                }
            }
        }

        public double Get(int n, int m)
        {
            return _kernel[n, m];
        }

        private static double Normal(int x, int y, double sigma)
        {


            return 1 / 2.0 * Math.PI * sigma * sigma * Math.Exp(-(x * x + y * y) / (2 * sigma * sigma));
        }
    }
}