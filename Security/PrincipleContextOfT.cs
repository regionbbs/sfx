using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Security
{
    public class PrincipleContext<T> : PrincipalContext
        where T: Principal
    {
        public PrincipleContext() : base(typeof(T))
        {
        }

        public PrincipleContext(string AuthenticationThumbprint) : base(typeof(T), AuthenticationThumbprint)
        {
        }
    }
}
