using Biblioteca_Virtual.DataBase;
using Biblioteca_Virtual.Identity;
using Biblioteca_Virtual.Serviços;
using Biblioteca_Virtual.Serviços.Livros;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Biblioteca_Virtual
{
    public class Program
    {
        public static async void Main(string[] args)
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
            builder.Services.AddScoped<IUsuarios_Interface, Usuarios_Features>();
            builder.Services.AddScoped<ILivro_Interface, Livro_Features>();

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<MeuDbContext>()
            .AddDefaultTokenProviders();

            // Criação do app depois de configurar os serviços
            var app = builder.Build();

            using (var scope =  app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                await Roles.Gerador_Papeis(services);
            }


            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
      .AddEntityFrameworkStores<MeuDbContext>()
      .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
