using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sfx.Security
{
    public interface IAuthenticationContext
    {
        void ConfigureAuthenticationData(object AuthenticationData);
        void ConfigureAuthenticationProvider<TAuthenticationProvider>() 
            where TAuthenticationProvider : IAuthenticationProvider;
        void Authenticate();
    }
}
