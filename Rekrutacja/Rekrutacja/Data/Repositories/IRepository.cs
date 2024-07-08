using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Soneta.Business;

namespace Rekrutacja.Data.Repositories
{
    public interface IRepository<T, M>
        where T : Row
        where M : Module
    {
        IQueryable<T> GetSelected();

        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate);

        void Save(IEnumerable<T> entities, Dictionary<string, object> updateObj);
    }
}
