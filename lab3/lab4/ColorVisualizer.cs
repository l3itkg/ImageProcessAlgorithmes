using System;
using System.Drawing;

namespace lab4
{
    public static class ColorVisualizer
    {
        public static Bitmap DrawGraphic(double[][] Sab, int CountIso)
        {
            var btm = new Bitmap(Sab[0].Length, Sab.Length);

            var min = double.MaxValue;
            var max = double.MinValue;
            foreach (var t in Sab)
                foreach (var t1 in t)
                {
                    min = Math.Min(min, Math.Abs(t1));
                    max = Math.Max(max, Math.Abs(t1));
                }

            for (var i = 0; i < Sab.GetLength(0); i++)
                for (var j = 0; j < Sab[0].Length; j++)
                {
                    var colorInd = (int)((Math.Abs(Sab[i][j]) - min) * CountIso / (max - min));
                    btm.SetPixel(j, i, GetColor(CountIso, colorInd));
                }
            return btm;

        }

        public static Color GetColor(int CountIso, int index)
        {
            if (index < 0 || index > CountIso)
                throw new IndexOutOfRangeException();

            double MMin = 1;
            double MMax = 1200;

            var dm = (MMax - MMin) / (CountIso - 1);

            int R = 0, G = 0, B = 0;
            var m_rab = MMin + index * dm;

            int di, mo;
            di = (int)m_rab / 256;
            mo = (int)(m_rab - di * 256);
            switch (di)
            {
                case 0:
                    R = 0;
                    G = mo;
                    B = 255;
                    break;
                case 1:
                    R = 0;
                    G = 255;
                    B = 255 - mo;
                    break;
                case 2:
                    R = mo;
                    G = 255;
                    B = 0;
                    break;

                case 3:
                    R = 255;
                    G = 255 - mo;
                    B = 0;
                    break;
                case 4:
                    R = 255;
                    G = 0;
                    B = mo;
                    break;

                case 5:
                    R = 255 - mo;
                    G = 0;
                    B = 255;
                    break;
            }

            return Color.FromArgb(R, G, B);
        }

        public static void DrawSignatureTwoPowers(Graphics g, Image img, int timeMin, int timeMax, int min, int max)
        {
            var newImg = (Bitmap)img.Clone();
            for (int i = 0; i < newImg.Width; i += 50)
            {
                var num = (double)i / newImg.Width * (timeMax - timeMin);
                g.DrawString(num.ToString("F1"), new Font("Times New Roman", 7), new SolidBrush(Color.Azure), i - 4, 0);
            }

            for (int i = 0; i < newImg.Height; i += 40)
            {
                var num = (double)i / newImg.Height * (max - min);
                g.DrawString(num.ToString("F1"), new Font("Times New Roman", 7), new SolidBrush(Color.Azure), 0, i);
            }


        }
    }
}
