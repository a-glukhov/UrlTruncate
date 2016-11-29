namespace UrlTruncate.Service.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using UrlTruncate.Model.Models;

    /// <summary>
    /// The TruncatedUrlService interface.
    /// </summary>
    public interface ITruncatedUrlService
    {
        /// <summary>
        /// Adds new truncated link
        /// </summary>
        /// <param name="url">
        /// A new url to truncate
        /// </param>
        /// <returns>
        /// The task of operation
        /// </returns>
        Task<TruncatedUrl> Add(TruncatedUrl url);

        /// <summary>
        /// Gets all truncated links
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/> of truncated links.
        /// </returns>
        IEnumerable<TruncatedUrl> GetAll();

        /// <summary>
        /// Get link within specified where condition
        /// </summary>
        /// <param name="where">
        /// The where expression
        /// </param>
        /// <returns>
        /// The <see cref="TruncatedUrl"/> link.
        /// </returns>
        TruncatedUrl Get(Func<TruncatedUrl, bool> where);

        /// <summary>
        /// Updates specified url
        /// </summary>
        /// <param name="url">
        /// The url
        /// </param>
        /// <returns>
        /// The task  operation/>.
        /// </returns>
        Task<TruncatedUrl> Update(TruncatedUrl url);

        /// <summary>
        /// Saves changes
        /// </summary>
        /// <returns>
        /// The task operation/>.
        /// </returns>
        Task<int> SaveAsync();

        /// <summary>
        /// Truncates incoming original url
        /// </summary>
        /// <param name="baseUrl">
        /// The base url.
        /// </param>
        /// <param name="originalUrl">
        /// The original url.
        /// </param>
        /// <returns>
        /// The task operation/>.
        /// </returns>
        Task<TruncatedUrl> TruncateUrl(string baseUrl, string originalUrl);

        /// <summary>
        /// Perform url jump registration
        /// </summary>
        /// <param name="shortUrl">
        /// A short url
        /// </param>
        /// <returns>
        /// The task operation/>.
        /// </returns>
        Task<TruncatedUrl> Jump(string shortUrl);
    }
}
