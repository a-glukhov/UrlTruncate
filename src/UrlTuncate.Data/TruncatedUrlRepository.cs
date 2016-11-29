namespace UrlTuncate.Data
{
    using System.Threading.Tasks;

    using UrlTruncate.Data.Repository;
    using UrlTruncate.Model.Models;

    /// <summary>
    /// The truncated url repository.
    /// </summary>
    public class TruncatedUrlRepository :
        RepositoryBase<TruncatedUrl, TuDbModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TruncatedUrlRepository"/> class.
        /// </summary>
        /// <param name="factory">
        /// The factory.
        /// </param>
        public TruncatedUrlRepository(IDatabaseFactory<TuDbModel> factory) 
            : base(factory)
        {
        }
    }
}