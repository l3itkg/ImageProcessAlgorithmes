using Common;
using Common.Interfaces;

namespace Plugins.LinearBrightnessChanel
{
    class LinearBrightnessChannelPlugin : IPlugin
    {
        public void Process(IDirectBitmap bitmap, AbstractParameter parameter)
        {
            bitmap.AdjustBrightness();
        }
    }
}
