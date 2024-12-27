using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_Virtual.Models
{
    [Table("Livros")]
    public class Livro_Model
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Livro")]
        public string Nome_Livro { get; set; }


        [Required]
        [Column("Editora")]
        public string Editora { get; set; }

        [Required]
        [Column("Autor")]
        public string Autor { get; set; }

        [Required]
        [Column("Ano")]
        public int Ano { get; set; }

        [Column("Emprestado")]
        public bool Emprestado { get; set; } = false;
    }

    public enum AtributosLivro
    {
        Nome_Livro=1,
        Editora=2,
        Autor=3,
        Ano=4,
    }

}
