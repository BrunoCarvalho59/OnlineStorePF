using Core.Models.Utilizador;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayNome = "Bruno",
                    Email = "bruno@test.com",
                    UserName = "bruno@test.com",
                    Morada = new Morada
                    {
                        primeiroNome = "Bruno",
                        ultimoNome = "Carvalho",
                        rua = "Quinta S. Pedro Hab 5",
                        localidade = "Miranda do Corvo",
                        country = "PT",
                        zip = "3220-220"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }

            // Usuário Admin e role "Admin"
            var adminUser = await userManager.FindByEmailAsync("admin@example.com");

            if (adminUser == null)
            {
                adminUser = new AppUser
                {
                    DisplayNome = "Admin",
                    UserName = "admin@example.com",
                    Email = "admin@example.com"
                };

                await userManager.CreateAsync(adminUser, "Admin@123");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // Usuário GestorLoja e role "GestorLoja"
            var gestorLojaUser = await userManager.FindByEmailAsync("gerente@example.com");

            if (gestorLojaUser == null)
            {
                gestorLojaUser = new AppUser
                {
                    DisplayNome = "Gerente",
                    UserName = "gerente@example.com",
                    Email = "gerente@example.com"
                };

                await userManager.CreateAsync(gestorLojaUser, "Gerente@123");
                await userManager.AddToRoleAsync(gestorLojaUser, "GerenteLoja");
            }
        }

        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            // Adicionar os roles "Admin" e "GestorLoja"
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("GestorLoja"))
            {
                await roleManager.CreateAsync(new IdentityRole("GestorLoja"));
            }
        }

    }
}