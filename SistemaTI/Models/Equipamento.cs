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

        [Display(Name = "Descrição")]
        public string EquipDescricao
        {
            get
            {
                return string.Concat(Local + " - " + Modelo + " - " + NuSerie); // Retorna concatenação do Nome da Unidade com o tipo
            }
        }

        [Display(Name = "Numero de Serie")]
        public string NuSerie { get; set; }

        [Display(Name = "Numero de patrimonio")]
        public string NuPatrimonio { get; set; }

        // Tipo Impressora, notebook, computador
        [Display(Name = "Tipo")]
        public string EquipTipo { get; set; }

        [Display(Name ="Tipo - Fabricante - Modelo")]
        public string Modelo { get; set; }
        public ICollection<ModeloFabicante> ModeloFabicantes { get; set; }

        //Alugado ou proprio
        [Display(Name = "Origem")]
        public string EquipOrigem { get; set; }

        [Display(Name = "Valor do equipamento")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public float? EquipValor { get; set; } // Para tornar o int sem valor ou null foi usando o ?

        [Display(Name = "Local de Utilização")]
        public string Local { get; set; }
        public ICollection<Local> Locais { get; set; }


        [Display(Name = "Endereço de rede")]
        [DataType(DataType.Url)]
        [UIHint("OpenInNewWindow")]
        public string IP { get; set; }

        [Display(Name = "Situação")]
        public string Situacao { get; set; }

        [Display(Name = "Data de movimentação")]
        public DateTime DataMovimantacao { get; set; } = DateTime.Now;
    }

    public class Suprimento
    {
        [Key]
        public int idSuprimento { get; set; }

        public string ModeloEquipamento { get; set; }

        public string TipoSuprimento { get; set; }

        public int QtdSuprimento { get; set; }
    }

    public class Estoque
    {
        public string modelo { get; set; }
        public int qtdModelo { get; set; }
        public int QtdSuprimento { get; set; }
        public int EmEstoque { get; set; }
    }

    /*A class WiFi deve usar o Id do equipamento e localização para popular as caracteristicas: IP, Marca, Modelo e Localização
     * No index deve aparecer o SSID, Senha e Localização, os outros itens apanas nas outras telas
     */
    public class WiFi
    {
        [Key]
        public int IdWifi { get; set; }

        public string Equipamento { get; set; }

        public string Acesso { get; set; }

        public string UsuarioADM { get; set; }

        public string SenhaADM { get; set; }

        public string SSID { get; set; }

        public string SenhaSSID { get; set; }

        public int Localid { get; set; }

        public DateTime DataAlteracao { get; set; } = DateTime.Now; //Deve aparecer apenas na tela de detalhes

        public bool status { get; set; }
    }
}

