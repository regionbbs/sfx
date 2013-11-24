using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Framework
{
    public interface IException
    {
        string GetErrorMessage();
        string GetErrorSource();
        string GetErrorModule();
        IException GetInnerException();
    }
}
