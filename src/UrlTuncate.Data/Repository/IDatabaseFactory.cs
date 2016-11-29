using System;
using System.Data.Entity;

namespace UrlTruncate.Data.Repository
{
    public interface IDatabaseFactory<TDbContext> : IDisposable
        where TDbContext : DbContext
    {
        TDbContext Get();
    }
}
