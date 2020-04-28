using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Common.Interfaces;

namespace Common
{
    public class PluginLoader<T>
    {
        private readonly CompositionContainer _compositionContainer;

        public PluginLoader()
        {
            var directoryCatalog = new DirectoryCatalog(".");

            var aggregateCatalog = new AggregateCatalog(directoryCatalog);
            _compositionContainer = new CompositionContainer(aggregateCatalog);
            _compositionContainer.ComposeParts(this);
        }

        [ImportMany(typeof(IFactory))] public IEnumerable<T> Plugins { get; set; }
    }
}