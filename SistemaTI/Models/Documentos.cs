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
    public class Solicitacao
    {
        [Key]
        public int IdSolicitacao { get; set; }

        public DateTime DataRecebimento { get; set; } = DateTime.Now;

        // Irar gerar uma dropdown com a listagem de locais atendidos
        public string Local { get; set; }

        public string TextoSolicitacao { get; set; }

        // Irar gerar uma dropdown com a listagem de equipamentos, na pagina de detalhes deve retornar com os dados dos equipamento: Número de Série,	Patrimônio,	Locado ou Próprio
        public string Equipamento { get; set; }


        //Não precisa aparecer na tela de criação

        /* Situação da solicitação 
         * ao criar a solicitação - Vermelho;
         * Aguardando a manutenção - Amarelo;
         * Solicitação já atendida - Verde.
         */
        public string SolitacaoStatus { get; set; }

        public string OrdemServico { get; set; }

        public DateTime DataAtendimento { get; set; }
    }
}
