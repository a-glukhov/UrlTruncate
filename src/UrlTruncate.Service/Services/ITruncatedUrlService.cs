using UrlTruncate.Model.Models;

namespace UrlTruncate.Service.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface ITruncatedUrlService
    {
        Task<TruncatedUrl> Add(TruncatedUrl url);

        IEnumerable<TruncatedUrl> GetAll();

        TruncatedUrl Get(Func<TruncatedUrl, bool> where);

        Task<TruncatedUrl> Update(TruncatedUrl url);

        Task<int> SaveAsync();

        Task<TruncatedUrl> TruncateUrl(string baseUrl, string originalUrl);

        Task<TruncatedUrl> Jump(string shortUrl);
    }
}
