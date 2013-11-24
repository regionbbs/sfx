using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Security
{
    public interface IPrincipalContext
    {
        bool IsAuthenticated();
        IAuthenticationContext GetAuthenticationContext();
        IAuthorizationContext GetAuthorizationContext();
    }
}
