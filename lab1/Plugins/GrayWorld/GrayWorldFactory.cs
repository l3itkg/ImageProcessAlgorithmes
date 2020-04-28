using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Plugins.GrayWorld
{
    [Export(typeof(IFactory))]
    class GrayWorldFactory : IFactory
    {
        public IPlugin CreatePlugin()
        {
            return new GrayWorldPlugin();
        }

        public AbstractParameter CreateParameters()
        {
            return new GrayWorldParameter();
        }

        public string Name()
        {
            return "Серый мир";
        }
    }
}
