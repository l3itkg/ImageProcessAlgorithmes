using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Plugins.LinearBrightnessChanel
{
    [System.ComponentModel.Composition.Export(typeof(IFactory))]
    public class LinearBrightnessChannelFactory : IFactory
    {
        public IPlugin CreatePlugin()
        {
            return new LinearBrightnessChannelPlugin();
        }

        public AbstractParameter CreateParameters()
        {
            return new LinearBrightnessChannelParemeter();
        }

        public string Name()
        {
            return "Поканальное растяжение гистограммы яркости";
        }
    }
}
