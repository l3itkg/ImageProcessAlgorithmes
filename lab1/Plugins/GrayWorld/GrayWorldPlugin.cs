using Common;
using Common.Interfaces;

namespace Plugins.GrayWorld
{
    public class GrayWorldPlugin : IPlugin
    {
        public void Process(IDirectBitmap bitmap, AbstractParameter parameter)
        {
            bitmap.ProcessGrayWorld();

        }
    }
}