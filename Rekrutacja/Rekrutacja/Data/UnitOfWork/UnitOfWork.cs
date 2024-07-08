using Soneta.Business;
using System;

namespace Rekrutacja.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public Session Session { get; }
        private ITransaction _transaction;


        public UnitOfWork(Session session)
        {
            Session = session ?? throw new ArgumentNullException(nameof(session));
        }


        public ITransaction BeginTransaction()
        {
            _transaction = Session.Logout(true);
            return _transaction;
        }

        public void Commit()
        {
            _transaction.CommitUI();
        }

        public void Save()
        {
            Session.Save();
        }

        public T GetEntity<T>(T entity) 
            where T : Row
        {
            return Session.Get(entity);
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            Session?.Dispose();
        }
    }
}
