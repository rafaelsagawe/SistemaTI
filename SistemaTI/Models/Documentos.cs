using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTI.Models
{

    public class Recebido
    {
        [Key]
        public int IdDocumento { get; set; }
        // Tipos -> Memorando, Oficio, processo, 

        [Display(Name ="Tipo")]
        public string TipoDocumento { get; set; }

        [Display(Name ="Data de recebimento")]
        public DateTime DataRecebimento { get; set; } = DateTime.Now;
        
        // Listagem de locais atendidos 
        [Display(Name = "Solicitante")]
        public string origem { get; set; }

        public string Assunto { get; set; }

        public string Texto { get; set; }

        // Atendido ou não, esperando, apenas notificação
        public string Status { get; set; }

        // Caso seja manutenção deve se escolher o equipamento
        [Display(Name ="Para manutenção de Equipamento")]
        public string Equipamento { get; set; }

        public DateTime UltimaMovimentacao { get; set; } = DateTime.Now;

    }
    public class Enviado
    {
        
        [Key]
        public int IdEnviado { get; set; }

        [Required(ErrorMessage = "Campo obrigarorio")]
        [Display(Name = "Numero do documento")]
        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "Campo obrigarorio")]
        [Display(Name = "Tipo do documento recebido")]
        public string TipoDocumento { get; set; }

        [Required(ErrorMessage = "Campo obrigarorio")]
        [Display(Name = "Destino do documento")]
        public string Destino { get; set; }

        [Required(ErrorMessage = "Campo obrigarorio")]
        public string Assunto { get; set; }

        [Display (Name ="Texto do documento")]
        public string ResumoTexto { get; set; } // Será necessario aplicar nessa area editor rich de texto para web

        //Não precisa aparecer na tela de criação

        public DateTime DataEnvio { get; set; } = DateTime.Now;

        public string SolitacaoStatus { get; set; }

        public DateTime DataAlteração { get; set; } = DateTime.Now;
    }
}
