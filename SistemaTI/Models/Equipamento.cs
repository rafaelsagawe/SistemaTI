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
        public int EquipValor { get; set; }

        [Display(Name = "Local de Utilização")]
        public string Local { get; set; }

        [Display(Name = "Endereço")]
        [DataType(DataType.Url)]
        public string IP { get; set; }


    }
}

