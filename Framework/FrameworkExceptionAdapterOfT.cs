using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Framework
{
    public class FrameworkExceptionAdapter<TException> : FrameworkExceptionAdapter
        where TException : Exception
    {
        public FrameworkExceptionAdapter(TException Exception) : base(Exception)
        {
        }

        public FrameworkExceptionAdapter(
            TException Exception, string Source = null, string Module = null)
            : base(Exception, Source, Module)
        {
        }
    }
}

