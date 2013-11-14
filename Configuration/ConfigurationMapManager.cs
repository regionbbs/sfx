using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Framework.Configuration
{
    public class ConfigurationMapManager
    {
        public static ConfigurationSectionMapManager FromSection(string SectionPath)
        {
            return new ConfigurationSectionMapManager(SectionPath);
        }
    }
}
