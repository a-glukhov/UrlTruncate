
namespace UrlTruncate.Service.Providers
{

    using UrlTruncate.Data.Repository;
    using UrlTruncate.Service.Services;

    using UrlTuncate.Data;

    /// <summary>
    /// Service provider
    /// </summary>
    public class TruncatedUrlServiceProvider : ITruncatedUrlServiceProvider
    {
        /// <summary>
        /// The database factory.
        /// </summary>
        private readonly IDatabaseFactory<TuDbModel> databaseFactory;

        /// <summary>
        /// The truncated url service.
        /// </summary>
        private ITruncatedUrlService truncatedUrlService;

        /// <summary>
        /// The lock obj.
        /// </summary>
        private readonly object lockObj = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="TruncatedUrlServiceProvider"/> class.
        /// </summary>
        public TruncatedUrlServiceProvider()
        {
            this.databaseFactory = new DatabaseFactory();
        }

        /// <summary>
        /// Gets the truncated url service.
        /// </summary>
        public ITruncatedUrlService TruncatedUrlService
        {
            get
            {
                if (this.truncatedUrlService == null)
                {
                    lock (this.lockObj)
                    {
                        this.truncatedUrlService = new TruncatedUrlService(new TruncatedUrlRepository(this.databaseFactory));
                    }
                }

                return this.truncatedUrlService;
            }
        }
    }
}