using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_Virtual.Models
{
    [Table("UsuariosLivros")]
    public class UsuariosLivros_Model
    {
        [Key]
        [Column("Id")]
        public string Id { get; set; }

        [ForeignKey("Usuario")]
        [Column("Usuario_Id")]
        public int Usuario_Id { get; set; }

        [ForeignKey("Livro")]
        [Column("Livro_Id")]
        public int Livro_Id { get; set; }
    }
}

