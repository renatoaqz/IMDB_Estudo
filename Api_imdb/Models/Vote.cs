using Api_imdb.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_imdb.Models
{
    [Table("Votes")]
    public class Vote : BaseEntity
    {
        [Required]
        [Range(0,4)]
        public short ValueVote { get; set; }

        [ForeignKey("IdMovie")]
        public virtual Movie Movie { get; set; }
    }
}
