using Microsoft.AspNetCore.Identity;

namespace Biblioteca_Virtual.Identity
{
    public class Roles
    {
        public static async Task GeradorRoles(IServiceProvider serviceProvider)
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
