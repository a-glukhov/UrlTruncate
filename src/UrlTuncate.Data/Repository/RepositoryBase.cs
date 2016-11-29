using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace UrlTruncate.Data.Repository
{
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using UrlTruncate.Model;

    /// <summary>
    /// The repository base.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    /// <typeparam name="TDbContext">
    /// </typeparam>
    public abstract class RepositoryBase<T, TDbContext> : IRepository<T>
        where T : Entity where TDbContext : DbContext
    {
        private readonly IDbSet<T> dbset;

        private readonly TDbContext context;

        protected RepositoryBase(IDatabaseFactory<TDbContext> factory)
        {
            this.context = factory.Get();
            this.dbset = this.context.Set<T>();
        }


        public virtual void Add(T entity)
        {
            this.dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            this.dbset.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public async Task<int> SaveAsync()
        {
            return await this.context.SaveChangesAsync();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.dbset.ToList();
        }

        public virtual T Get(Func<T, Boolean> where)
        {
            return this.dbset.Where(where).FirstOrDefault();
        }
    }
}