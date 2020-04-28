using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Core.Models
{
    public class DynamicSegmentationResult
    {
        public DynamicSegmentationResult(DirectBitmap image, int[,] serments, int segmentsCount)
        {
            Image = image;
            SegmentsMap = serments;
            SegmentsCount = segmentsCount;
        }

        public DirectBitmap Image { get; set; }
        public int SegmentsCount { get; set; }
        public int[,] SegmentsMap { get; set; }
    }
}
