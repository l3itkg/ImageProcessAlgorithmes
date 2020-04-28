using Common;
using Common.Interfaces;

namespace Plugins.SobelEdgeDetect
{
    public class SobelEdgeDetectPlugin : IPlugin
    {
        public void Process(IDirectBitmap bitmap, AbstractParameter parameter)
        {
            DirectBitmapExtensionBase.ApplyConvolutionFilter(bitmap, Kernel.Sobel3Horizontal(),
                Kernel.Sobel3Vertical());

        }
    }
}