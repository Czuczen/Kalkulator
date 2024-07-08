using Rekrutacja.Data.UnitOfWork;
using Rekrutacja.Parameters;
using Soneta.Business;
using Soneta.Business.App;
using Soneta.EI;
using Soneta.Kadry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static Soneta.Ksiega.ZestawienieKS;

namespace Rekrutacja.Data.Repositories
{
    public class Repository<T, M> : IRepository<T, M>
         where T : Row
         where M : Module
    {
        private readonly IUnitOfWork _unitOfWork;

        public Context Cx { get; set; }


        public Repository(Context cx, SessionParameters sessionParameters)
        {
            Cx = cx;
            _unitOfWork = new UnitOfWork.UnitOfWork(Cx.Login.CreateSession(sessionParameters.ReadOnly, sessionParameters.Config, sessionParameters.Name));
        }


        public IQueryable<T> GetSelected()
        {
            if (!Cx.Contains(typeof(T[])))
            {
                throw new InvalidOperationException("Invalid context for retrieving data.");
            }

            var items = Cx[typeof(T[])] as T[];
            if (items == null || items.Length == 0)
            {
                throw new InvalidOperationException("No items selected.");
            }

            return items.AsQueryable();
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return GetSelected().Where(predicate);
        }

        public void Save(IEnumerable<T> entities, Dictionary<string, object> updateObj)
        {
            using (_unitOfWork.BeginTransaction())
            {
                foreach (var entity in entities)
                {
                    var entityInSession = _unitOfWork.GetEntity(entity);
                    foreach (var item in updateObj)
                        entityInSession.Features[item.Key] = item.Value;
                }
                
                _unitOfWork.Commit();
            }

            _unitOfWork.Save();
        }
    }
}
