using Microsoft.AspNetCore.Identity;
using SistemaTI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTI.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRegrasAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Semear Regras
            await roleManager.CreateAsync(new IdentityRole(Enums.Regras.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Regras.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Regras.Moderador.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Regras.Basico.ToString()));
        }

        // Metodo para criação do usuário Superadministrador
        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "superadmin",
                Email = "superadmin@adm.com",
                PrimeiroNome = "Super",
                SobreNome = "Admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Regras.Basico.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Regras.Moderador.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Regras.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Regras.SuperAdmin.ToString());
                }

            }
        }

    }
}
