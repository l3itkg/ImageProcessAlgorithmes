using System.ComponentModel.Composition;
using Common.Interfaces;

namespace Plugins.Scale
{
    [Export(typeof(IFactory))]
    public class ScaleFactory : IFactory
    {
        public IPlugin CreatePlugin()
        {
            return new ScalePlugin();
        }

        public AbstractParameter CreateParameters()
        {
            return new ScaleParameter();
        }

        public string Name()
        {
            return "Масштабирование";
        }
    }
}
