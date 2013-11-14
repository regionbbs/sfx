using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Security
{
    public interface IKeySecretGenerator
    {
        string CreateKey();
        string CreateSecret();
        string ResetKey();
        string ResetSecret();
        string RenewKey();
        string RenewSecret();
    }
}
