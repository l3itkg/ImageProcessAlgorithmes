using System.ComponentModel.Composition;
using Common.Interfaces;

namespace Plugins.Glass
{
    [Export(typeof(IFactory))]
    public class GlassFactory : IFactory
    {
        public IPlugin CreatePlugin()
        {
            return new GlassPlugin();
        }

        public AbstractParameter CreateParameters()
        {
            return new GlassParameter();
        }

        public string Name()
        {
            return "Эффект стекло";
        }
    }
}
