using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Framework.Data
{
    public interface IQuery
    {
        IQuery AsStatementQuery(); // default execution type, run statement.
        IQuery AsTableQuery(); // query to table.
        IQuery AsViewQuery(); // query to view.
        IQuery AsStoredProcQuery(); // execute stored procedure.
        IQuery AsUDFQuery(); // set-valued function (User-defined Function with resultset)
        IQuery AsTVFQuery(); // table-valued funtion (User-defined Function with table)
        IQuery AsSVFQuery(); // scalar-valued function (User-defined Function with scalar value)
        IQuery ScaffoldingModelAsParams(); // scaffold model property to map to parameter.
        IQuery DefineParameter<TModel>(Func<TModel, Tuple<string, PropertyInfo>> PropertySpecifier);
        IQuery DefineParameters<TModel>();
        IQuery DefineParameters<TModel>(Func<TModel, IEnumerable<Tuple<string, PropertyInfo>>> PropertySpecifier);
    }
}
