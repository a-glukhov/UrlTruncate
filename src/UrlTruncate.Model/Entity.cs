
namespace UrlTruncate.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class Entity
    {
        /// <summary>
        /// url identity
        /// </summary>
        [Column("id")]
        public int Id { get; set; }
    }
}
