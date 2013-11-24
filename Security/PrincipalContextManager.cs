using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Security
{
    public class PrincipalContextManager
    {
        public IPrincipalContext GetPrincipleContext(string AuthenticatedThumbprint = null)
        {
            if (string.IsNullOrEmpty(AuthenticatedThumbprint))
                return PrincipalContextFactory.CreateAnonymousContext();

            return PrincipalContextFactory.CreateNamedContext(AuthenticatedThumbprint);
        }
    }
}
