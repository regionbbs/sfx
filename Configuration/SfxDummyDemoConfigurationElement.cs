using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Framework.Configuration
{
    public class SfxDummyDemoConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("name")]
        public string Name { get { return base["name"].ToString(); } }
    }
}
