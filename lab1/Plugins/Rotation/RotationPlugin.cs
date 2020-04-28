using Common;
using Common.Interfaces;

namespace Plugins.Rotation
{
    public class RotationPlugin : IPlugin
    {
        public void Process(IDirectBitmap bitmap, AbstractParameter parameter)
        {
            bitmap.ProcessRotation(((RotationParameter)parameter).Angle);
        }
    }
}
