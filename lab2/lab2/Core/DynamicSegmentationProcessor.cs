using System;
using System.Collections.Generic;
using System.Drawing;
using lab2.Core.Models;

namespace lab2.Core
{
    public class DynamicSegmentationProcessor
    {
        private readonly int[,] _deltas = { { 1, 0 }, { 0, 1 }, { 0, -1 }, { -1, 0 }, { -1, -1 }, { 1, 1 }, { -1, 1 }, { 1, -1 } };
        private readonly Random _random = new Random();

        public DynamicSegmentationResult Segment(DirectBitmap image, double treshold, bool highlight)
        {
            var serments = new int[image.Height, image.Width];
            var segmentsCount = 0;
            var newImg = (DirectBitmap)image.Clone();

            for (var i = 0; i < image.Height; i++)
                for (var j = 0; j < image.Width; j++)
                {
                    if (serments[i, j] != 0)
                        continue;
                    ProcessSegment(image, newImg, treshold, serments, ++segmentsCount, i, j, GetRandomColor());
                }
            if (highlight)
                HighlightSegments(newImg, serments);
            return new DynamicSegmentationResult(newImg, serments, segmentsCount);
        }

        private void HighlightSegments(DirectBitmap image, int[,] serments)
        {
            var squaredSegments = GetSquaredSegments(serments);
            foreach (var pair in squaredSegments)
                image.DrawRectangle(pair.Value, GetRandomColor());
        }

        private static Dictionary<int, Rectangle> GetSquaredSegments(int[,] serments)
        {
            var segmentsRectangles = new Dictionary<int, Rectangle>();

            for (var i = 0; i < serments.GetLength(0); i++)
                for (var j = 0; j < serments.GetLength(1); j++)
                {
                    var curSegment = serments[i, j];
                    if (!segmentsRectangles.ContainsKey(curSegment))
                    {
                        segmentsRectangles[curSegment] = new Rectangle(j, i, 1, 1);
                        continue;
                    }
                    var rect = segmentsRectangles[curSegment];
                    segmentsRectangles[curSegment] = new Rectangle(rect.X, rect.Y, j - rect.X, i - rect.Y);
                }
            return segmentsRectangles;
        }

        private Color GetRandomColor()
        {
            return Color.FromArgb(_random.Next(256), _random.Next(256), _random.Next(256));
        }

        private Tuple<int, int, int> ColorToTuple(Color c) =>
            Tuple.Create((int)c.R, (int)c.G, (int)c.B);

        private Tuple<int, int, int> Add(Tuple<int, int, int> t1, Tuple<int, int, int> t2) =>
            Tuple.Create(t1.Item1 + t2.Item1, t1.Item2 + t2.Item2, t1.Item3 + t2.Item3);

        private Color AvgToColor(Tuple<int, int, int> t1, int n) =>
            Color.FromArgb(t1.Item1 / n, t1.Item2 / n, t1.Item3 / n);

        private void ProcessSegment(DirectBitmap image, DirectBitmap newImg, double treshold, int[,] serments,
            int segment, int y, int x, Color color)
        {
            var q = new Queue<Tuple<int, int>>();
            q.Enqueue(Tuple.Create(x, y));
            var n = 1;
            var colorsAvg = ColorToTuple(image.GetPixel(x, y));
            while (q.Count != 0)
            {
                var current = q.Dequeue();
                int xcur = current.Item1, ycur = current.Item2;
                serments[ycur, xcur] = segment;
                newImg.SetPixel(xcur, ycur, color);
                n++;
                colorsAvg = Add(colorsAvg, ColorToTuple(image.GetPixel(xcur, ycur)));

                for (var i = 0; i < _deltas.GetLength(0); i++)
                {
                    var xnew = xcur + _deltas[i, 0];
                    var ynew = ycur + _deltas[i, 1];

                    if (xnew >= 0 && xnew < image.Width && ynew >= 0 && ynew < image.Height &&
                        serments[ynew, xnew] == 0 &&
                        Measure(image.GetPixel(xnew, ynew), AvgToColor(colorsAvg, n)) <= treshold)
                    {
                        q.Enqueue(Tuple.Create(xnew, ynew));
                        serments[ynew, xnew] = -1;
                    }
                }
            }
        }

        private double Measure(Color from, Color to)
        {
            return Math.Sqrt(Math.Pow(from.R - to.R, 2) + Math.Pow(from.G - to.G, 2) + Math.Pow(from.B - to.B, 2));
        }
    }
}
