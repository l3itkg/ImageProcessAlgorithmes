using Common;
using Common.Interfaces;

namespace Plugins.CustomFilter
{
    public class CustomFilterPlugin : IPlugin
    {
        public void Process(IDirectBitmap bitmap, AbstractParameter parameter)
        {
            DirectBitmapExtensionBase.ApplyConvolutionFilter(bitmap,
                new Kernel(((CustomFilterParameter)parameter).Matrix));
            bitmap.Process();
        }
    }
}
