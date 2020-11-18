using System.Collections.Generic;
using System.Linq;

namespace TBMMORPG.Infrastructure.Data.Interface
{
    public interface IRepository<T> where T : BaseDomain
    {
        IQueryable<T> Table { get; }
        IQueryable<T> TableNotTracking { get; }
        T GetById(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity, bool force = false);
        void AddRange(IEnumerable<T> entity);
        void UpdateRange(IEnumerable<T> entity);
        void DeleteRange(IEnumerable<T> entities, bool force = false);
    }
}
