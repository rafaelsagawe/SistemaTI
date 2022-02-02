using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTI.Data
{
    /* https://www.tektutorialshub.com/asp-net-core/add-custom-fields-to-user-in-asp-net-core-identity/
     * Está classe (ApplicationUser) se trata de uma etenção da IdentityUser
     * Alterar a class ApplicationDbContext 
     * Na Startup.cs atualizar AddDefaultIdentity
     * Em Register.cshtml.cs alerar as IdentityUser para ApplicationUser, incluir no InputModel
     * Adicionar os campos no formulario em Register.cshtml
     * Trocar parametros em _LoginPartial.cshtml
     */

    public class ApplicationUser : IdentityUser 
    {
        public string PrimeiroNome { get; set; }
        public string SobreNome { get; set; }
    }
}
