using Sfx.Framework.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stupid.Framework.TestClient.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var sfxSection = ConfigurationManager.GetSection("sfx") as SfxConfigurationSection;

            var configMapManager = new ConfigurationMapManager();
            var dummyMap = new ConfigurationMap<Dummy, SfxDummyConfigurationElement>();

            dummyMap.Property(c => c.V1).Required().Map(c => c.V1).Default("PROG_DEFAULT");
            dummyMap.Property(c => c.V2).Required().Map(c => c.V2).Default("V2_DEFAULT");

            configMapManager.Register<Dummy, SfxDummyConfigurationElement>(dummyMap);
            var dummy = configMapManager.
                ExtractFromProvider<Dummy, SfxDummyConfigurationElement>(sfxSection.Dummy);

            
        }
    }
}
