using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Framework.Data
{
    public interface IQueryExecutor
    {
        void Execute();
        T Execute<T>();
        IEnumerable<T> Execute<T>();
    }
}