using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Framework.Data
{
    public class InsertQuery : IQuery
    {

        public IQuery DefineQueryType(QueryTypes Type)
        {
            throw new NotImplementedException();
        }

        public IQuery AsStatementQuery()
        {
            throw new NotImplementedException();
        }

        public IQuery AsTableQuery()
        {
            throw new NotImplementedException();
        }

        public IQuery AsViewQuery()
        {
            throw new NotImplementedException();
        }

        public IQuery AsStoredProcQuery()
        {
            throw new NotImplementedException();
        }

        public IQuery AsUDFQuery()
        {
            throw new NotImplementedException();
        }

        public IQuery AsTVFQuery()
        {
            throw new NotImplementedException();
        }

        public IQuery AsSVFQuery()
        {
            throw new NotImplementedException();
        }

        public IQuery ScaffoldingModelAsParams()
        {
            throw new NotImplementedException();
        }

        public IQuery DefineParameter<TModel>(Func<TModel, Tuple<string, System.Reflection.PropertyInfo>> PropertySpecifier)
        {
            throw new NotImplementedException();
        }

        public IQuery DefineParameters<TModel>(Func<TModel, IEnumerable<Tuple<string, System.Reflection.PropertyInfo>>> PropertySpecifier)
        {
            throw new NotImplementedException();
        }
    }
}
