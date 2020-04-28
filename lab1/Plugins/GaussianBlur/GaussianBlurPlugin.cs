using Common;
using Common.Interfaces;

namespace Plugins.GaussianBlur
{
    public class GaussianBlurPlugin : IPlugin
    {
        public void Process(IDirectBitmap bitmap, AbstractParameter parameter)
        {
            bitmap.Process(((GaussianBlurParameter)parameter).Sigma);
        }
    }
}
