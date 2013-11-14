using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Sfx.Framework.Configuration
{
    public class SfxDummyConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("v1", IsRequired = false, DefaultValue = "")]
        public string V1 { get { return base["v1"].ToString(); } }
        [ConfigurationProperty("v2", IsRequired = false, DefaultValue = "")]
        public string V2 { get { return base["v2"].ToString(); } }
    }
}
