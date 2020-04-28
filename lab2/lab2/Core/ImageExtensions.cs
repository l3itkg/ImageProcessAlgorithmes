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
    public static class ImageExtensions
    {
        public static byte[] ToByteArrayARGB(this Bitmap image)
        {
            var pixelCount = image.Width * image.Height;

            var rect = new Rectangle(0, 0, image.Width, image.Height);

            var depth = Image.GetPixelFormatSize(image.PixelFormat);


            if (depth != 8 && depth != 24 && depth != 32)
            {
                throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
            }

            var bitmapData = image.LockBits(rect, ImageLockMode.ReadWrite,
                image.PixelFormat);


            var bytes = new byte[pixelCount * depth / 8];
            var intPtr = bitmapData.Scan0;

            Marshal.Copy(intPtr, bytes, 0, bytes.Length);
            image.UnlockBits(bitmapData);
            return bytes;
        }
    }
}
