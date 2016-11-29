using UrlTuncate.Data;

namespace UrlTruncate.Data.Repository
{
    /// <summary>
    /// The database factory.
    /// </summary>
    public class DatabaseFactory : IDatabaseFactory<TuDbModel>
    {
        /// <summary>
        /// The context.
        /// </summary>
        private TuDbModel context;

        /// <summary>
        /// The connection string.
        /// </summary>
        private readonly string connectionString;

        public DatabaseFactory()
            :this(string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseFactory"/> class.
        /// </summary>
        /// <param name="connectionString">
        /// The connection string.
        /// </param>
        public DatabaseFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Get the model
        /// </summary>
        /// <returns>
        /// The <see cref="TuDbModel"/>.
        /// </returns>
        public TuDbModel Get()
        {
            return this.context ?? (this.context = string.IsNullOrEmpty(this.connectionString) ? new TuDbModel() : new TuDbModel(this.connectionString));
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.context?.Dispose();
        }
    }
}
