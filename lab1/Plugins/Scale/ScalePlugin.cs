using Common;
using Common.Interfaces;

namespace Plugins.Scale
{
    public class ScalePlugin : IPlugin
    {
        public void Process(IDirectBitmap bitmap, AbstractParameter parameter)
        {
            bitmap.ProcessScale(((ScaleParameter)parameter).Scale);
        }
    }
}
