using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace Biblioteca_Virtual.Models
{
    [Table("Usuarios")]
    public class Usuario_Model
    {

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Email")]
        public string Email {  get; set; }

        [Column("Senha")]
        public string Senha {  get; protected set; }

        [Column("Matricula")]
        public string Matricula { get; set; }

        [Column("Curso")]
        public string Curso { get; set; }

        [Column("Quant_Livros_Posse")]
        public int? Quant_Livros_Posse { get; set; }
    }
}
