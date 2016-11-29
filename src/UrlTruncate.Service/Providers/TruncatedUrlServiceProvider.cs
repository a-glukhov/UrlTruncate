
namespace UrlTruncate.Service.Providers
{

    using UrlTruncate.Data.Repository;
    using UrlTruncate.Service.Services;

    using UrlTuncate.Data;

    public class TruncatedUrlServiceProvider: ITruncatedUrlServiceProvider
    {
        private IDatabaseFactory<TuDbModel> databaseFactory;

        private ITruncatedUrlService truncatedUrlService;
        private readonly object lockObj = new object();
        public TruncatedUrlServiceProvider()
        {
            this.databaseFactory = new DatabaseFactory();
        }

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