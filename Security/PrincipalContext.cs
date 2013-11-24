using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sfx.Security
{
    public class PrincipalContext : IPrincipalContext
    {
        private Type _principleType = null;
        private string _authenticatedThumbprint = null;
        private string _principleToken = null;
        private bool _authenticatd = false;

        public PrincipalContext()
        {
            this._principleType = typeof(Principal);
            this._authenticatedThumbprint = null;
            this._authenticatd = false;
        }

        protected PrincipalContext(Type PrincipleType)
        {
            this._principleType = PrincipleType;
            this._authenticatedThumbprint = null;
            this._authenticatd = false;
        }

        public PrincipalContext(string AuthenticatedThumbprint)
        {
            this._principleType = typeof(Principal);
            this._authenticatedThumbprint = AuthenticatedThumbprint;
            ValidateThumbprint();
        }

        protected PrincipalContext(Type PrincipleType, string AuthenticatedThumbprint)
        {
            this._principleType = PrincipleType;
            this._authenticatedThumbprint = AuthenticatedThumbprint;
            ValidateThumbprint();
        }

        private void ValidateThumbprint()
        {
            // check thumbprint is exist.
            if (this.EnsureTokenValid())
            {
                this._authenticatd = false;
                return;
            }

            // decrypt thumbprint by server token to get principle identity.
            this._principleToken = this.DecryptPrincipleToken();

            if (string.IsNullOrEmpty(this._principleToken))
            {
                this._authenticatd = false;
                return;
            }

            // ensure principle is exist.
            if (!this.EnsurePrinciple())
            {
                this._authenticatd = false;
                return;
            }

            this._authenticatd = true;
        }
        private string DecryptPrincipleToken()
        {
            var serverTokenProvider = AuthenticationTokenStoreFactory.GetServerRandomToken();
            return null;
        }
        private string EncryptPrincipleToken()
        {
            var serverTokenProvider = AuthenticationTokenStoreFactory.GetServerRandomToken();
            return null;
        }

        private bool EnsurePrinciple()
        {
            throw new NotImplementedException();
        }

        private bool EnsureTokenValid()
        {
            throw new NotImplementedException();
        }

        public bool IsAuthenticated()
        {
            return this._authenticatd;
        }

        public IAuthenticationContext GetAuthenticationContext()
        {
            throw new NotImplementedException();
        }

        public IAuthorizationContext GetAuthorizationContext()
        {
            throw new NotImplementedException();
        }
    }
}
