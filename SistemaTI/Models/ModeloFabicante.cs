using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTI.Models
{
    public class ModeloFabicante
    {
        [Key]
        public int idModelo { get; set; }

        [Display(Name = "Fabricante e Modelo")]
        public string Descricao 
        {
            get
            {
                return string.Concat(Tipo + " - " + Fabicante + " - " + Modelo);
            }
        }

        [Required(ErrorMessage = "Infromação Obrigatória")]
        [Display(Name = "Tipo do equipamento")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Infromação Obrigatória")]
        [Display(Name = "Fabricante do equipamento")]
        public string Fabicante { get; set; }

        [Required(ErrorMessage = "Infromação Obrigatória")]
        [Display(Name = "Modelo do equipamento")]
        public string Modelo { get; set; }

    }
}
