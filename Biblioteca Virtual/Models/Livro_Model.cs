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

        [Column("Livro")]
        public string Livro { get; set; }

        [Column("Editora")]
        public string Editora { get; set; }

        [Column("Autor")]
        public string Autor { get; set; }

        [Column("Ano")]
        public int Ano { get; set; }

        [Column("Emprestado")]
        public bool Emprestado { get; set; }
    }
}
