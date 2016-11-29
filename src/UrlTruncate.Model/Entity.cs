
namespace UrlTruncate.Model
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Base class for models
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// url identity
        /// </summary>
        [Column("id")]
        public int Id { get; set; }
    }
}
