using Api_imdb.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_imdb.Models
{
    [Table("Authors")]
    public class Author : BaseEntity
    {
        
        [Column("Name"), MaxLength(100)]
        public string Name { get; set; }

        //public virtual ICollection<Movie> Movies { get; set; }
    }
}
