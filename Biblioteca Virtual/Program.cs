using Biblioteca_Virtual.DataBase;
using Biblioteca_Virtual.Identity;
using Biblioteca_Virtual.Serviços;
using Biblioteca_Virtual.Serviços.Livros;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Biblioteca_Virtual
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuração do DbContext (antes de builder.Build())
            builder.Services.AddDbContext<MeuDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ILivro_Interface, Livro_Features>();

            // Criação do app depois de configurar os serviços
            var app = builder.Build();

            using (var scope =  app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                await Roles.GeradorRoles(services);
            }

            // Configuração do identity, vinculando todos os usuarios a uma role e armazenamento no banco de dados "MeuDbContext"
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
      .AddEntityFrameworkStores<MeuDbContext>()
      .AddDefaultTokenProviders();


            //Implementação dos requisitos de senha
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 6;
            });


            //Dimensionamento para a página de login/cadastro/logout em caso de bloqueio de acesso
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/api/Account/Login";
                options.LogoutPath = "/api/Account/Logout";
                options.AccessDeniedPath = "/api/Account/AccessDenied";
            });


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
