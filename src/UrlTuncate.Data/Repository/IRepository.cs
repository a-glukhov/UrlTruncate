using System.Collections.Generic;

namespace UrlTruncate.Data.Repository
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using UrlTruncate.Model;

    /// <summary>
    /// The Repository interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IRepository<T> where T : Entity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> SaveAsync();
        IEnumerable<T> GetAll();
        T Get(Func<T, Boolean> where);
    }
}
