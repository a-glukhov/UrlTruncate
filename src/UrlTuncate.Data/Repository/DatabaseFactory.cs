using UrlTuncate.Data;

namespace UrlTruncate.Data.Repository
{
    public class DatabaseFactory : IDatabaseFactory<TuDbModel>
    {
        private TuDbModel context;

        private readonly string connectionString;

        public DatabaseFactory()
            :this(string.Empty)
        {
        }

        public DatabaseFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public TuDbModel Get()
        {
            return this.context ?? (this.context = string.IsNullOrEmpty(this.connectionString) ? new TuDbModel() : new TuDbModel(this.connectionString));
        }

        public void Dispose()
        {
            this.context?.Dispose();
        }
    }
}
