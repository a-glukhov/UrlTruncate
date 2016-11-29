namespace UrlTuncate.Data
{
    using System.Threading.Tasks;

    using UrlTruncate.Data.Repository;
    using UrlTruncate.Model.Models;

    public class TruncatedUrlRepository :
        RepositoryBase<TruncatedUrl, TuDbModel>
    {
        public TruncatedUrlRepository(IDatabaseFactory<TuDbModel> factory) 
            : base(factory)
        {
        }
    }
}