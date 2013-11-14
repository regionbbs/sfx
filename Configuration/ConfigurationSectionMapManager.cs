using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Framework.Configuration
{
    public class ConfigurationSectionMapManager
    {
        private ConfigurationSection _section = null;
        private List<object> _configurationMaps = new List<object>();

        internal ConfigurationSectionMapManager(string SectionPath)
        {
            this._section = ConfigurationManager.GetSection(SectionPath) as ConfigurationSection;
        }

        public ConfigurationMap<TConfigConsumer, TConfigProvider> DefineMap<TConfigConsumer, TConfigProvider>()
            where TConfigConsumer : class
            where TConfigProvider : ConfigurationElement
        {
            var map = new ConfigurationMap<TConfigConsumer, TConfigProvider>();

            var mapQuery = this._configurationMaps.Where(c =>
                CheckMapTypeExists<TConfigConsumer, TConfigProvider>(
                c as ConfigurationMap<TConfigConsumer, TConfigProvider>));

            if (mapQuery.Any())
                this._configurationMaps.Remove(mapQuery.First());

            this._configurationMaps.Add(map);

            return map;
        }

        public ConfigurationMap<TConfigConsumer, TConfigProvider> DefineMap<
            TConfigConsumer, TConfigProvider, TConfigProviderCollection>()
            where TConfigConsumer : class
            where TConfigProvider : ConfigurationElement
            where TConfigProviderCollection : ConfigurationElementCollection
        {
            var map = new ConfigurationMap<TConfigConsumer, TConfigProvider>();

            var mapQuery = this._configurationMaps.Where(c =>
                CheckMapTypeExists<TConfigConsumer, TConfigProvider>(
                c as ConfigurationMap<TConfigConsumer, TConfigProvider>));

            if (mapQuery.Any())
                this._configurationMaps.Remove(mapQuery.First());

            map.FromCollection<TConfigProviderCollection>();

            this._configurationMaps.Add(map);

            return map;
        }

        public bool CheckConsumerMapToProviderRegistered<TConfigConsumer, TConfigProvider>()
            where TConfigConsumer : class
            where TConfigProvider : ConfigurationElement
        {
            var mapQuery = this._configurationMaps.Where(c =>
                CheckMapTypeExists<TConfigConsumer, TConfigProvider>(c as ConfigurationMap<TConfigConsumer, TConfigProvider>));

            return mapQuery.Any();
        }

        public TConfigConsumer ExtractValues<TConfigConsumer, TConfigProvider>()
            where TConfigConsumer : class
            where TConfigProvider : ConfigurationElement
        {
            var mapQuery = this._configurationMaps.Where(c =>
                CheckMapTypeExists<TConfigConsumer, TConfigProvider>(c as ConfigurationMap<TConfigConsumer, TConfigProvider>));

            if (!mapQuery.Any())
                return null;

            var mapDef = mapQuery.First() as ConfigurationMap<TConfigConsumer, TConfigProvider>;
            var propertyQuery = this._section.GetType().GetProperties().Where(c => c.PropertyType == mapDef.Provider);

            if (!propertyQuery.Any())
                return null;

            var provider = propertyQuery.First().GetValue(this._section) as TConfigProvider;

            return mapDef.ExtractValues(provider);
        }

        public IEnumerable<TConfigConsumer> ExtractValuesFromCollection<TConfigConsumer, TConfigProvider>()
            where TConfigConsumer : class
            where TConfigProvider : ConfigurationElement
        {
            var mapQuery = this._configurationMaps.Where(c =>
                CheckMapTypeExists<TConfigConsumer, TConfigProvider>(c as ConfigurationMap<TConfigConsumer, TConfigProvider>));

            if (!mapQuery.Any())
                yield return null;

            var mapDef = mapQuery.First() as ConfigurationMap<TConfigConsumer, TConfigProvider>;
            var collectionProperty = this._section.GetType().GetProperties()
                .Where(c => c.PropertyType == mapDef.FromCollectionType);

            if (!collectionProperty.Any())
                yield return null;

            var collection = collectionProperty.First().GetValue(this._section) as ConfigurationElementCollection;
            var cursor = collection.GetEnumerator();

            while (cursor.MoveNext())
                yield return mapDef.ExtractValues(cursor.Current as TConfigProvider);
        }

        private TConfigConsumer ExtractConfigValues<TConfigConsumer, TConfigProvider>(TConfigProvider Provider)
            where TConfigConsumer : class
            where TConfigProvider : ConfigurationElement
        {
            var mapQuery = this._configurationMaps.Where(c =>
                CheckMapTypeExists<TConfigConsumer, TConfigProvider>(c as ConfigurationMap<TConfigConsumer, TConfigProvider>));

            if (!mapQuery.Any())
                return null;

            var mapDef = mapQuery.First() as ConfigurationMap<TConfigConsumer, TConfigProvider>;
            return mapDef.ExtractValues(Provider);
        }

        private bool CheckMapTypeExists<TConfigConsumer, TConfigProvider>(ConfigurationMap<TConfigConsumer, TConfigProvider> map)
            where TConfigConsumer : class
            where TConfigProvider : ConfigurationElement
        {
            if (map == null)
                return false;

            return (
                map.Consumer == typeof(TConfigConsumer) &&
                map.Provider == typeof(TConfigProvider)
                );
        }
    }
}
