using Common;
using Common.Interfaces;

namespace Plugins.Glass
{
    public class GlassPlugin : IPlugin
    {
        public void Process(IDirectBitmap bitmap, AbstractParameter parameter)
        {
            bitmap.Process(((GlassParameter) parameter).Radius);
        }
    }
}