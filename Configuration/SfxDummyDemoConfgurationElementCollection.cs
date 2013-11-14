using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Framework.Configuration
{
    public class SfxDummyDemoConfgurationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new SfxDummyDemoConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as SfxDummyDemoConfigurationElement).Name;
        }

        public IEnumerable<TConfigProvider> GetCollectionItems<TConfigProvider>()
            where TConfigProvider: ConfigurationElement
        {
            var cursor = this.GetEnumerator();

            while (cursor.MoveNext())
                yield return cursor.Current as TConfigProvider;
        }
    }
}
