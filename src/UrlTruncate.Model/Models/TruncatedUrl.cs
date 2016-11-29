using System;

namespace UrlTruncate.Model.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;

    /// <summary>
    /// A model for truncated url
    /// </summary>
    public class TruncatedUrl : Entity
    {   
        /// <summary>
        /// A short url presentation
        /// </summary>
        [Column("short_url")]
        [Required]
        [StringLength(100)]
        public string ShortUrl { get; set; }

        /// <summary>
        /// An original url presentation
        /// </summary>
        [Column("original_url")]
        [Required]
        [StringLength(2000)]
        public string OriginalUrl { get; set; }

        /// <summary>
        /// A datetime the truncated url was created
        /// </summary>
        [Column("creation_time", TypeName = "datetime2")]
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// A number that indicated a count of url jumps
        /// </summary>
        [Column("jumps")]
        public int Jumps { get; set; }

        /*
        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            TruncatedUrl t = obj as TruncatedUrl;
            if (t == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this.OriginalUrl == t.OriginalUrl);
        }

        public bool Equals(TruncatedUrl t)
        {
            // If parameter is null return false:
            if (t == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this.OriginalUrl == t.OriginalUrl);
        }

        public override int GetHashCode()
        {
            if (string.IsNullOrEmpty(this.OriginalUrl)) return base.GetHashCode();

            return this.OriginalUrl.GetHashCode();
        }
        */
    }

    public static class TruncatedUrlExtension
    {
        public static bool WithSameShortUrl(this TruncatedUrl truncatedUrl, string shortUrl)
        {
            var uri = new Uri(truncatedUrl.ShortUrl);

            return shortUrl == uri.Segments.LastOrDefault();
        }

        public static bool WithSameOriginal(this TruncatedUrl truncatedUrl, string originalUrl)
        {
            var cleanOriginal = truncatedUrl.OriginalUrl.Replace(" ", string.Empty);
            return cleanOriginal == originalUrl;
        }
    }
}