using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Framework.Data
{
    public abstract class DefaultQuery : IQuery, IQueryExecutor
    {
        protected QueryTypes Type { get; set; }
        protected QueryStatementTypes StatementType { get; private set; }
        protected bool IsAutoScaffolingModelAsParams { get; private set; }
        protected Type QueryModel { get; private set; }

        public DefaultQuery()
        {
            this.Type = QueryTypes.SelectQuery;
            this.StatementType = QueryStatementTypes.DirectlyQuery;
            this.IsAutoScaffolingModelAsParams = false;
        }

        public IQuery AsStatementQuery()
        {
            this.StatementType = QueryStatementTypes.DirectlyQuery;
            return this;
        }

        public IQuery AsTableQuery()
        {
            this.StatementType = QueryStatementTypes.TableQuery;
            return this;
        }

        public IQuery AsViewQuery()
        {
            this.StatementType = QueryStatementTypes.ViewQuery;
            return this;
        }

        public IQuery AsStoredProcQuery()
        {
            this.StatementType = QueryStatementTypes.StoredProcQuery;
            return this;
        }

        public IQuery AsUDFQuery()
        {
            this.StatementType = QueryStatementTypes.UDFQuery;
            return this;
        }

        public IQuery AsTVFQuery()
        {
            this.StatementType = QueryStatementTypes.TVFQuery;
            return this;
        }

        public IQuery AsSVFQuery()
        {
            this.StatementType = QueryStatementTypes.SVFQuery;
            return this;
        }

        public IQuery ScaffoldingModelAsParams()
        {
            this.IsAutoScaffolingModelAsParams = true;
            return this;
        }

        public IQuery DefineParameter<TModel>(Func<TModel, Tuple<string, System.Reflection.PropertyInfo>> PropertySpecifier)
        {
            throw new NotImplementedException();
        }

        public IQuery DefineParameters<TModel>()
        {
            this.QueryModel = typeof(TModel);
            return this;
        }

        public IQuery DefineParameters<TModel>(Func<TModel, IEnumerable<Tuple<string, System.Reflection.PropertyInfo>>> PropertySpecifier)
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public T Execute<T>()
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IQueryExecutor.Execute<T>()
        {
            throw new NotImplementedException();
        }
    }
}
