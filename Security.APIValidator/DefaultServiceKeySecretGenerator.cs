using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sfx.Security;

namespace Sfx.Security.APIValidator
{
    public class DefaultServiceKeySecretGenerator : IKeySecretGenerator
    {
        public virtual string CreateKey()
        {
            throw new NotImplementedException();
        }

        public virtual string CreateSecret()
        {
            throw new NotImplementedException();
        }

        public virtual string ResetKey()
        {
            throw new NotImplementedException();
        }

        public virtual string ResetSecret()
        {
            throw new NotImplementedException();
        }

        public virtual string RenewKey()
        {
            throw new NotImplementedException();
        }

        public virtual string RenewSecret()
        {
            throw new NotImplementedException();
        }
    }
}
