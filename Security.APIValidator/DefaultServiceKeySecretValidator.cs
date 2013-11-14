using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sfx.Security;

namespace Security.APIValidator
{
    public class DefaultServiceKeySecretValidator : IKeySecretValidator
    {
        public void Validate(string Key, string Secret)
        {
            throw new NotImplementedException();
        }
    }
}
