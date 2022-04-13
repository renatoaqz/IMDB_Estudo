using Api_imdb.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_imdb.Models
{
    [Table("Movies")]
    public class Movie : BaseEntity
    {
        [Required]
        [Column("Title"), MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        [Required]
        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }

        public virtual IList<Vote> Votes { get; set; }
    }
}
