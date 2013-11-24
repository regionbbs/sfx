using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Security
{
    public abstract class AuthenticationToken
    {
        protected string Token { get; set; }
        protected TimeSpan ValidDuration { get; set; }

        public virtual byte[] Encrypt(byte[] PlainData)
        {
            throw new NotImplementedException();
        }

        public virtual byte[] Decrypt(byte[] EncryptData)
        {
            throw new NotImplementedException();
        }
    }
}
