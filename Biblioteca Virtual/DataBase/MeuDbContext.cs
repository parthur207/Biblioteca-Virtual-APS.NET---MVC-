using Biblioteca_Virtual.Identity;
using Biblioteca_Virtual.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_Virtual.DataBase
{
    public class MeuDbContext : IdentityDbContext<IdentityUser>
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
        {
        }
        public DbSet<Livro_Model> Livros { get; set; }
        public DbSet<Emprestimos_Model> Emprestimos { get; set; }

        public static async Task Gerador_Papeis(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles = { "Admin", "UsuarioComum" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }



    }
}
