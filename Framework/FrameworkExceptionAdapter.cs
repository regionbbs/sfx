using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Framework
{
    public class FrameworkExceptionAdapter : IException
    {
        protected Exception ExceptionAdaptee { get; private set; }
        protected string Source { get; private set; }
        protected string Module { get; private set; }

        public FrameworkExceptionAdapter(Exception Exception)
        {
            this.ExceptionAdaptee = Exception;
        }

        public FrameworkExceptionAdapter(
            Exception Exception, string Source = null, string Module = null)
            : this(Exception)
        {
            this.Source = Source;
            this.Module = Module;
        }
        
        public string GetErrorMessage()
        {
            return this.ExceptionAdaptee.Message;
        }

        public string GetErrorSource()
        {
            return this.Source;
        }

        public string GetErrorModule()
        {
            return this.Module;
        }

        public IException GetInnerException()
        {
            if (this.ExceptionAdaptee.InnerException == null)
                return null;

            return new FrameworkExceptionAdapter(this.ExceptionAdaptee.InnerException);
        }
    }
}
