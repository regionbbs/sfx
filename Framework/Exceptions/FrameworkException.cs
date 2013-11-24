using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Framework.Exceptions
{
    public abstract class FrameworkException : Exception, IException
    {
        private IException Exception { get; set; }
        private string Message { get; set; }
        private string Module { get; set; }

        public FrameworkException(IException Exception)
        {
            this.Exception = Exception;
        }

        public FrameworkException(string Message, string Source = null, string Module = null)
            : base(Message, InnerException.GetException())
        {
            this.Source = Source;
            this.Module = Module;
        }

        public string GetErrorMessage()
        {
            return this.Message;
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
            return this.Exception;
        }
    }
}
