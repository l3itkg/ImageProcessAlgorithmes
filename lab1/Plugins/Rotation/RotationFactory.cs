using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Plugins.Rotation
{
    [Export(typeof(IFactory))]
    public class RotationFactory : IFactory
    {
        public IPlugin CreatePlugin()
        {
            return new RotationPlugin();
        }

        public AbstractParameter CreateParameters()
        {
            return new RotationParameter();
        }

        public string Name()
        {
            return "Поворот";
        }
    }
}
