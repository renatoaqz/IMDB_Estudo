using Api_imdb.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_imdb.Models
{
    [Table("Gender")]
    public class Gender : BaseEntity
    {
        
        [Column("Name"), MaxLength(50)]
        public string Name { get; set; }

        //public virtual ICollection<Movie> Movies { get; set; }
    }
}
