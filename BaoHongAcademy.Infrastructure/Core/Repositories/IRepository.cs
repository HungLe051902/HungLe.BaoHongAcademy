using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaoHongAcademy.Infrastructure.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Find(object id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetDataPaging(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
