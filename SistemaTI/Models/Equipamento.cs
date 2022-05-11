using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTI.Models
{
    public class Equipamento
    {
        [Key]
        public int IdEquipamento { get; set; }

        public string DescricaoEquipamento
        {
            get
            {
                return string.Concat(EspecificacaoId + NuSerie + NuPatrimonio);
            }
        }

        [Display(Name = "Numero de Serie")]
        public string NuSerie { get; set; }

        [Display(Name = "Numero de patrimonio")]
        public string NuPatrimonio { get; set; }

        [Display(Name = "Valor do equipamento")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public float? EquipValor { get; set; } // Para tornar o int sem valor ou null foi usando o ?

        [Display(Name = "Endereço de rede")]

        public string IP { get; set; }

        [Display(Name = "Situação")]
        public string Situacao { get; set; }

        [Display(Name = "Data de documentação")]
        public DateTime DataMovimantacao { get; set; } = DateTime.Now;


        // Propriedade de navegação
        // Geração de referencia entre Locais
        [Display(Name = "Local de Utilização")]
        public int? LocalId { get; set; }
        public Local Local { get; set; }

        // Ligação com Especificação
        public int? EspecificacaoId { get; set; }
        [Display(Name = "Especificações")]
        public Especificacao Especificacao { get; set; }

        // Ligação com Processos
        public int? ProcessoId { get; set; }
        [Display(Name = "Processo")]
        public Processo Processo { get; set; }

        public int ItemProcessoID { get; set; }

        public ICollection<Manutencao> EquipamentoManutencao { get; set; }

    }

    public class Especificacao
    {
        [Key]
        public int EspecificacaoId { get; set; }

        public string Descricao
        {
            get
            {
                return string.Concat(Tipo + " - " + Fabicante + " - " + Modelo);
            }
        }
        // Tipo Impressora, notebook, computador
        [Required(ErrorMessage = "Infromação Obrigatória")]
        [Display(Name = "Tipo do equipamento")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Infromação Obrigatória")]
        [Display(Name = "Fabricante do equipamento")]
        public string Fabicante { get; set; }

        [Required(ErrorMessage = "Infromação Obrigatória")]
        [Display(Name = "Modelo do equipamento")]
        public string Modelo { get; set; }

        // Propriedade de Navegação
        // Com Equipamento
        public ICollection<Equipamento> EquipamentosEspecificacao { get; set; }

        public ICollection<Suprimento> SuprimentosEspecificacao { get; set; }

        public ICollection<WiFi> WiFiModelo { get; set; }

        public ICollection<Manutencao> ManutencaosEspeficacao { get; set; }
    }

    public class Suprimento
    {
        [Key]
        public int idSuprimento { get; set; }

        // Propriedade de navegação Especificação
        public int EspecificacaoId { get; set; }

        [Display(Name = "Modelo do Equipamento")]
        public Especificacao Especificacao { get; set; }
        
        // ---//--- 

        public string TipoSuprimento { get; set; }

        public int QtdSuprimento { get; set; }
    }

     /*Falta a criação de uma página para apresentar os quantitativos de suprimentos com relação ao quantitavido de equipamentos, assim gerando um controle de estoque.*/

    /*A class WiFi deve usar o Id do equipamento e localização para popular as caracteristicas: IP, Marca, Modelo e Localização
     * No index deve aparecer o SSID, Senha e Localização, os outros itens apanas nas outras telas
     */
    public class WiFi
    {
        [Key]
        public int IdWifi { get; set; }

        public string EnderecoIP { get; set; }

        public string UsuarioADM { get; set; }

        public string SenhaADM { get; set; }

        public string SSID { get; set; }

        public string SenhaSSID { get; set; }

        public DateTime DataAlteracao { get; set; } = DateTime.Now; //Deve aparecer apenas na tela de detalhes

        public bool status { get; set; }

        // propridade de navegação, onde e qual equipamento

        // Geração de referencia entre Locais
        [Display(Name = "Local de Utilização")]
        public int LocalId { get; set; }
        public Local Local { get; set; }

        // Especificação para gerar os modelos
        public int EspecificacaoId { get; set; }

        [Display(Name = "Modelos")]
        public Especificacao Especificacao { get; set; }

    }


    public class Manutencao
    {
        [Key]
        public int ManutencaoID { get; set; }

        [Required(ErrorMessage = "Motivo da manutenção é obrigatório")]
        public string Motivo { get; set; }

        public DateTime? DataSolicitacao { get; set; } = DateTime.Now;

        //
        public int? EspecificacaoId { get; set; }

        [Display(Name = "Modelos")]
        public Especificacao Especificacao { get; set; }

        public int? EquipamentoId { get; set; }
        public Equipamento Equipamento { get; set; }

        public int? LocalId { get; set; }
        public Local Local { get; set; }

    }
}

