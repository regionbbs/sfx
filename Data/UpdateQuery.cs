using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Framework.Data
{
    public class UpdateQuery : DefaultQuery
    {
        public UpdateQuery()
        {
            this.Type = QueryTypes.UpdateQuery;
        }

        public override string GetQueryStatement()
        {
            throw new NotImplementedException();
        }

        public override System.Data.IDataParameter GetQueryParameters()
        {
            throw new NotImplementedException();
        }
    }
}
