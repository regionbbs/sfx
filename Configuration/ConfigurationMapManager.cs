using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Framework.Configuration
{
    public class ConfigurationMapManager
    {
        private List<object> ConfigurationMaps = new List<object>();

        public void Register<TConfigConsumer, TConfigProvider>(
            ConfigurationMap<TConfigConsumer, TConfigProvider> ConfigMap)
            where TConfigConsumer: class
            where TConfigProvider: ConfigurationElement
        {
            var mapQuery = this.ConfigurationMaps.Where(c =>
                {
                    var map = c as ConfigurationMap<TConfigConsumer, TConfigProvider>;
                    return (
                        map.Consumer == typeof(TConfigConsumer) && 
                        map.Provider == typeof(TConfigProvider)
                        );
                });

            if (mapQuery.Any())
                this.ConfigurationMaps.Remove(mapQuery.First());

            this.ConfigurationMaps.Add(ConfigMap);
        }

        public bool CheckConsumerMapToProviderRegistered<TConfigConsumer, TConfigProvider>()
            where TConfigConsumer: class
            where TConfigProvider: ConfigurationElement
        {
            var mapQuery = this.ConfigurationMaps.Where(c =>
                {
                    var map = c as ConfigurationMap<TConfigConsumer, TConfigProvider>;
                    return (
                        map.Consumer == typeof(TConfigConsumer) && 
                        map.Provider == typeof(TConfigProvider)
                        );
                });

            return mapQuery.Any();
        }

        public TConfigConsumer ExtractFromProvider<TConfigConsumer, TConfigProvider>(TConfigProvider Provider)
            where TConfigConsumer : class
            where TConfigProvider : ConfigurationElement
        {
            var mapQuery = this.ConfigurationMaps.Where(c =>
            {
                var map = c as ConfigurationMap<TConfigConsumer, TConfigProvider>;
                return (
                    map.Consumer == typeof(TConfigConsumer) &&
                    map.Provider == typeof(TConfigProvider)
                    );
            });

            if (!mapQuery.Any())
                return null;

            var mapDef = mapQuery.First() as ConfigurationMap<TConfigConsumer, TConfigProvider>;
            return mapDef.ExtractFromProvider(Provider);
        }

        public IEnumerable<TConfigConsumer> ExtractFromProvider<TConfigConsumer, TConfigProvider>(IEnumerable<TConfigProvider> Providers)
            where TConfigConsumer : class
            where TConfigProvider : ConfigurationElement
        {
            var mapQuery = this.ConfigurationMaps.Where(c =>
            {
                var map = c as ConfigurationMap<TConfigConsumer, TConfigProvider>;
                return (
                    map.Consumer == typeof(TConfigConsumer) &&
                    map.Provider == typeof(TConfigProvider)
                    );
            });

            if (!mapQuery.Any())
                yield return null;

            foreach (var provider in Providers)
            {
                var mapDef = mapQuery.First() as ConfigurationMap<TConfigConsumer, TConfigProvider>;
                yield return mapDef.ExtractFromProvider(provider);
            }
        }
    }
}
