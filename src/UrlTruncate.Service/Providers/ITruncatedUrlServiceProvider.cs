namespace UrlTruncate.Service.Providers
{
    using UrlTruncate.Service.Services;

    public interface ITruncatedUrlServiceProvider
    {
        ITruncatedUrlService TruncatedUrlService { get; }
    }
}
