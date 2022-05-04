
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Application.Common.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(params object[] keys);
        void Add(TEntity entity);
        void Delete(object id);
        void DeleteSeveral(List<TEntity> entities);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate, params string[] excludedProperties);
        IQueryable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
        void Dispose();
        DbSet<TEntity> dbSet { get; set; }
    }
}
