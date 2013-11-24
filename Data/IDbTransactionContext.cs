using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sfx.Framework.Data
{
    public interface IDbTransactionContext
    {
        void Create(IDbTransaction Transaction);
        void RegisterQueryAttendee(IQueryExecutor QueryExecutor);
        void Commit();
        void Rollback();
    }
}
