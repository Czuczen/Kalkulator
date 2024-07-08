using Soneta.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekrutacja.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        ITransaction BeginTransaction();

        void Commit();

        void Save();

        T GetEntity<T>(T entity) 
            where T : Row;
    }
}
