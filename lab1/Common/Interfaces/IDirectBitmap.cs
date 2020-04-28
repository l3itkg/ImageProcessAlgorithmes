using System;
using System.Drawing;

namespace Common.Interfaces
{
    public interface IDirectBitmap : ICloneable, IDisposable
    {
        int Height { get; }
        int Width { get; }
        void SetPixel(int x, int y, Color color);
        Color GetPixel(int x, int y);
        void Resize(int width, int height);
    }
}