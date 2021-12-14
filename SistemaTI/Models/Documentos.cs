using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTI.Models
{

    public class Documentos
    {
        [Key]
        public int IdDocumento { get; set; }

        // Tipos -> Memorando: recebido ou enviado, Oficio: recebido ou enviado, Ordem de Serviço, Termo de Emprestimo, Termo de Retirada.

        public string TipoDocumento { get; set; }

        public int NumeroDocumento { get; set; }

        public string Destinatario { get; set; }

        public string Assunto { get; set; }

        public string Conteudo { get; set; }

        public DateTime DataDocumento { get; set; } = DateTime.Now;

        // Atendido ou não, esperando, apenas notificação
        public string Status { get; set; }

        // Urgente, Alta, Media, Baixa
        public enum grauImportancia 
        {
            Urgente, Alta, Media, Baixa
        }

    }
}
