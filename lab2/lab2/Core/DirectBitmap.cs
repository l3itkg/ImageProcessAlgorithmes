using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Core
{
    public class DirectBitmap
    {
        public DirectBitmap(int width, int height)
        {
            CreateBitmap(width, height);
        }

        public DirectBitmap(Bitmap bitmap)
        {
            Width = bitmap.Width;
            Height = bitmap.Height;
            bitmap = bitmap.Clone(new Rectangle(0, 0, Width, Height), PixelFormat.Format32bppPArgb);

            Bits = bitmap.ToByteArrayARGB();
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb,
                BitsHandle.AddrOfPinnedObject());
        }

        public Bitmap Bitmap { get; private set; }
        public byte[] Bits { get; private set; }
        public bool Disposed { get; private set; }

        protected GCHandle BitsHandle { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        public void DrawRectangle(Rectangle rect, Color c)
        {
            for (int i = rect.Y; i < rect.Y + rect.Height; i++)
            {
                SetPixel(rect.X, i, c);
                SetPixel(rect.X + rect.Width, i, c);

            }

            for (int i = rect.X; i < rect.X + rect.Width; i++)
            {
                SetPixel(i, rect.Y, c);
                SetPixel(i, rect.Y + rect.Height, c);
            }

        }

        public void SetPixel(int x, int y, Color color)
        {
            var offset = (y * 4 * Width + x * 4) % Bits.Length;
            Bits[(offset)] = color.R;
            Bits[(offset + 1)] = color.G;
            Bits[(offset + 2)] = color.B;
        }

        public Color GetPixel(int x, int y)
        {
            var offset = (y * 4 * Width + x * 4) % Bits.Length;
            return Color.FromArgb(Bits[offset + 3], Bits[offset], Bits[offset + 1], Bits[offset + 2]);
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }

        public object Clone()
        {
            return new DirectBitmap(Bitmap);
        }

        private void CreateBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new byte[width * height * 4];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb,
                BitsHandle.AddrOfPinnedObject());
            MakeBlackBitmap();
        }

        public void Resize(int width, int height)
        {
            Bitmap.Dispose();
            BitsHandle.Free();
            CreateBitmap(width, height);
        }

        private void MakeBlackBitmap()
        {
            for (var i = 0; i + 3 < Bits.Length; i += 4)
            {
                Bits[i + 3] = 255;
                Bits[i] = 0;
                Bits[i + 1] = 0;
                Bits[i + 2] = 0;
            }
        }

        private void MakeWhiteBitmap()
        {
            for (var i = 0; i < Bits.Length; i++)
            {
                Bits[i] = 255;
            }
        }
    }
}
