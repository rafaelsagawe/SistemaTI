using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTI.Models
{
    public class Processo
    {
        public int ProcessoId { get; set; }

        public string NumeroProcesso { get; set; }

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

        public ICollection<ItensProcesso> ItensProcesso { get; set; }

        public ICollection<Equipamento> EquipamentoProcesso { get; set; }
    }

    public class ItensProcesso
    {
        [Key]
        public int ItensProcessoId { get; set; }

        public string Item { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Quantidade")]
        public int QTD { get; set; }

        // Unidade, Saco, Kilo
        public string Medida { get; set; }

        // Propridade de Navegação
        public int ProcessoId { get; set; }
        public Processo Protocolo { get; set; }
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
        public int ProcessoId { get; set; }
        public Processo Protocolo { get; set; }
    }

    // Memorando Recebidos e/ou Enviados

    /* Os Memorandos devem se separados em dois index (Enviados e Recebidos);
     * Na criação do memorando escolhe a origem.
     */

    public class Documentos
    {
        [Key]
        public int IdDocumento { get; set; }

        // Tipos -> Memorando (Enviados e Recebidos), Oficio (Enviados e Recebidos) e processo (Enviados e Recebidos)
        [Required(ErrorMessage = "Campo obrigarorio")]
        [Display(Name = "Tipo do documento recebido")]
        public string TipoDocumento { get; set; }

        [Required(ErrorMessage = "Campo obrigarorio")]
        [Display(Name = "Numero do documento")]
        public string NumeroDocumento { get; set; }

        [Display(Name = "Data do inicio da Tramitação")]
        public DateTime DataInicioTramitacao { get; set; } = DateTime.Now;

        // Listagem de locais atendidos 
        [Required(ErrorMessage = "Campo obrigarorio")]
        [Display(Name = "Destino/Origem do documento")]
        public string DestinoOrigem { get; set; }

        [Display(Name = "Texto do documento")]
        public string Conteudo { get; set; } // Será necessario aplicar nessa area editor rich de texto para web

        // Atendido ou não, esperando, apenas notificação
        public string Status { get; set; }

        // Caso seja manutenção deve se escolher o equipamento
        [Display(Name = "Para manutenção de Equipamento")]
        public string Equipamento { get; set; }

        public DateTime UltimaMovimentacao { get; set; } = DateTime.Now;

    }
}
