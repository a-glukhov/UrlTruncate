namespace UrlTuncate.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    using UrlTruncate.Model.Models;

    public partial class TuDbModel : DbContext
    {
        public TuDbModel()
            : base("name=TuDbModel")
        {
        }

        public TuDbModel(string connectionString)
            : base(connectionString)
        {
        }
        public virtual DbSet<TruncatedUrl> TruncatedUrls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TruncatedUrl>()
                .Property(e => e.ShortUrl)
                .IsFixedLength();

            modelBuilder.Entity<TruncatedUrl>()
                .Property(e => e.OriginalUrl)
                .IsFixedLength();
        }
    }
}
