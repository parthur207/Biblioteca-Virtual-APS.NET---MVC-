using Biblioteca_Virtual.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_Virtual.DataBase
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
        {
        }
        public DbSet<Livro_Model> Livros { get; set; }
        public DbSet<UsuariosLivros_Model> UsuariosLivros { get; set; }
        public DbSet<Usuario_Model> Usuarios { get; set; }

        public DbSet<Admin_Model> Admin { get; set; }
    }
}
