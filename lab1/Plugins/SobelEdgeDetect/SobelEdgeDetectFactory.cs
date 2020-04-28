using System.ComponentModel.Composition;
using Common.Interfaces;

namespace Plugins.SobelEdgeDetect
{
    [Export(typeof(IFactory))]
    public class SobelEdgeDetectFactory : IFactory
    {
        public IPlugin CreatePlugin()
        {
            return new SobelEdgeDetectPlugin();
        }

        public AbstractParameter CreateParameters()
        {
            return new SobelEdgeDetectParameter();
        }

        public string Name()
        {
            return "Выделение границ оператором Собеля";
        }

        public string ConsoleName()
        {
            return "-s";
        }
    }
}
