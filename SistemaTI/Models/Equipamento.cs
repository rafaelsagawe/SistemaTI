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
                return string.Concat(Local + " - " + EquipTipo); // Retorna concatenação do Nome da Unidade com o tipo
            }
        }

        [Display(Name = "Numero de Serie")]
        public string NuSerie { get; set; }

        [Display(Name = "Numero de patrimonio")]
        public string NuPatrimonio { get; set; }

        // Tipo Impressora, notebook, computador
        [Display(Name = "Tipo")]
        public string EquipTipo { get; set; }

        public string Modelo { get; set; }

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
        public string IP { get; set; }




    }
}

