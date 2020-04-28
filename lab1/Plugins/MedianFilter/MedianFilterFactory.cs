using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Plugins.MedianFilter
{
    [Export(typeof(IFactory))]
    class MedianFilterFactory : IFactory
    {
        public IPlugin CreatePlugin()
        {
            return new MedianFilterPlugin();
        }

        public AbstractParameter CreateParameters()
        {
            return new MedianFilterParameter();
        }

        public string Name()
        {
            return "Медианная фильтрация";
        }
    }
}
