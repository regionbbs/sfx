using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Security
{
    public class PrincipalContextFactory
    {
        public static IPrincipalContext CreateAnonymousContext()
        {

        }

        public static IPrincipalContext CreateNamedContext(string AuthenticationThumbprint)
        {
            return null;
        }
    }
}
