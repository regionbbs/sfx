using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Framework.Configuration
{
    public class SfxConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("dummy", IsRequired = true)]
        public SfxDummyConfigurationElement Dummy
        {
            get { return base["dummy"] as SfxDummyConfigurationElement; }
        }

        [ConfigurationProperty("dummy2")]
        [ConfigurationCollection(typeof(SfxDummyDemoConfgurationElementCollection), 
            CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
        public SfxDummyDemoConfgurationElementCollection Dummy2
        {
            get { return base["dummy2"] as SfxDummyDemoConfgurationElementCollection; }
        }
    }
}
