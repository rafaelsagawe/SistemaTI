using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string NomeCompleto
        {
            set
            {
                NomeCompleto = PrimeiroNome + " " + SobreNome;
            }
        }
        public string PrimeiroNome { get; set; }

        public string SobreNome { get; set; }

        public int LimiteTroca{ get; set; } = 10;

        public byte[] PerfilFoto { get; set; }
    }

    public class UsuarioRegraViewModel
    {

        public string UserId { get; set; }
        public string PrimeiroNome { get; set; }
        public string SobreNome { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Regra { get; set; }
    }

    public class GerenciamentoRegraUsuarioViewModel
    {
        public string RegraId { get; set; }
        public string RegraNome { get; set; }
        public bool Selecao { get; set; }
    }
}