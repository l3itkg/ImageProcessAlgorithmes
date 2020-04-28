using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Plugins.CustomFilter
{
    [Export(typeof(IFactory))]
    public class CustomFilterFactory : IFactory
    {
        public IPlugin CreatePlugin()
        {
            return new CustomFilterPlugin();
        }

        public AbstractParameter CreateParameters()
        {
            return new CustomFilterParameter();
        }

        public string Name()
        {
            return "Пользовательский фильтр";
        }
    }
}
