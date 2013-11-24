using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sfx.Framework.Data
{
    public enum QueryStatementTypes
    {
        DirectlyQuery,
        TableQuery,
        ViewQuery,
        StoredProcQuery,
        UDFQuery,
        TVFQuery,
        SVFQuery
    }
}
