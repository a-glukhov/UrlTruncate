namespace UrlTruncate.Service.Providers
{
    using UrlTruncate.Service.Services;

    /// <summary>
    /// A provider service for <see cref="ITruncatedUrlService"/>
    /// </summary>
    public interface ITruncatedUrlServiceProvider
    {
        /// <summary>
        /// Gets the truncated url service.
        /// </summary>
        ITruncatedUrlService TruncatedUrlService { get; }
    }
}
