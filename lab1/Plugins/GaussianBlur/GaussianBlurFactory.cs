using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Plugins.GaussianBlur
{
    [Export(typeof(IFactory))]
    public class GaussianBlurFactory : IFactory
    {
        public IPlugin CreatePlugin()
        {
            return new GaussianBlurPlugin();
        }

        public AbstractParameter CreateParameters()
        {
            return new GaussianBlurParameter();
        }

        public string Name()
        {
            return "Размытие по Гауссу";
        }
    }
}
