using Microsoft.EntityFrameworkCore;
using SEMS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Infrastructure.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable
            where TEntity : class
    {
        private ApplicationDbContext applicationDbContext;
        public DbSet<TEntity> dbSet { get; set; }

        public Repository()
        {
        }

        public virtual TEntity GetByID(params object[] keys)
        {

            return dbSet.Find(keys);
        }

        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void DeleteSeveral(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.Delete(entity);
            }
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (applicationDbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate, params string[] excludedProperties)
        {
            dbSet.Attach(entityToUpdate);
            applicationDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            foreach (var ex in excludedProperties)
                applicationDbContext.Entry(entityToUpdate).Property(ex).IsModified = false;
        }

        public IQueryable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

    



        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    try
                    {
                        applicationDbContext.Dispose();
                    }
                    catch { }
                }
                disposed = true;
            }
        }

        ~Repository()
        {
            Dispose(false);
        }
    }
}
