using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTI.Models
{
    public class Protocolo
    {
        public int Id { get; set; }

        public string Processo { get; set; }

        public string Assunto { get; set; }

        public string Tipo { get; set; } // Aluguel, compra, prestação de Serviço

        public int Prazo { get; set; }

        [Display(Name = "Inicio de entrada")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataEntrada { get; set; }

        [Display(Name ="Ultima modificação")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataRegistro { get; set; } = DateTime.Now;

        [Display(Name = "Renovações")]
        public int Renovacao { get; set; }

        // Usuário que realizou o cadastro

        public string UsuarioCadastro { get; set; }

        // Propriedade de Navegação
        public ICollection<Tramitacao> Tramitar { get; set; }
    }


    public class Tramitacao
    {
        public int Id { get; set; }

        [Display(Name = "Movimentação")]
        public DateTime Movimentacao { get; set; } = DateTime.Now;

        [Display(Name ="Localização")]
        public string Localizacao { get; set; }

        // Usuário que Realizou a tramitação
        public string UsuarioTramitacao { get; set; }

        // Propriedade de Navegação
        public int ProtocoloId { get; set; }
        public Protocolo Protocolo { get; set; }
    }
}
