using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_Virtual.Identity
{
    [Table("Admin")]
    public class Admin_Identy: I
    {

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Senha")]
        private string Senha { get; set; }
    }
}
