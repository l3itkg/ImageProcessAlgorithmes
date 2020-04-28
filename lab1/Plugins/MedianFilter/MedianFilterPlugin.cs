using Common;
using Common.Interfaces;

namespace Plugins.MedianFilter
{
    public class MedianFilterPlugin : IPlugin
    {
        public void Process(IDirectBitmap bitmap, AbstractParameter parameter)
        {
            var radius = ((MedianFilterParameter) parameter).Radius;
            bitmap.ProcessMedianFilter(radius);

        }
    }
}