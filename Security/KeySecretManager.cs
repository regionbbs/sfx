using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Security
{
    public class KeySecretManager
    {
        private IKeySecretGenerator _generator = null;
        private IKeySecretValidator _validator = null;

        public KeySecretManager()
        {
            // load from configuration file or load default providers.
        }

        public KeySecretManager(IKeySecretGenerator Generator, IKeySecretValidator Validator)
        {
            this._generator = Generator;
            this._validator = Validator;
        }
    }
}
