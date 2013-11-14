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
            var configSectionManager = ConfigurationMapManager.FromSection("sfx");
            var dummyMap = configSectionManager.DefineMap<Dummy, SfxDummyConfigurationElement>();

            dummyMap.Property(c => c.V1).Required().Map(c => c.V1).Default("PROG_DEFAULT");
            dummyMap.Property(c => c.V2).Required().Map(c => c.V2).Default("V2_DEFAULT");

            var dummy = configSectionManager.ExtractConfigValues<Dummy, SfxDummyConfigurationElement>();

            var dummyMap2 = configSectionManager.DefineMap<dummy2, SfxDummyDemoConfigurationElement>();

            dummyMap2.Property(c => c.Name).Required().Map(c => c.Name);
            dummyMap2.FromCollection<SfxDummyDemoConfgurationElementCollection>();
            dummyMap2.FromContaimer<SfxConfigurationSection>();

            var dummy2 = configSectionManager.
                ExtractConfigValuesFromCollection<dummy2, SfxDummyDemoConfigurationElement>();
        }
    }
}
