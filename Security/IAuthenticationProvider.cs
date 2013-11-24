using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sfx.Security
{
    public interface IAuthenticationProvider
    {
        void Authenticate();
    }
}
