using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Security
{
    public interface IKeySecretValidator
    {
        void Validate(string Key, string Secret);
    }
}
