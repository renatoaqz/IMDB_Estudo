using Api_imdb.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_imdb.Models
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Required]
        [Column("FullName"), MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [Column("Login"), MaxLength(50)]
        public string Login { get; set; }

        [Required]
        [Column("Password"), MaxLength(200)]
        public string Password { get; set; }

        [Required]
        [Column("Role"), MaxLength(100) ]
        public string Role { get; set; }
        
        [MaxLength(500)]
        public string Token { get; set; }

        public bool Ativo { get; set; }
    }   
}
