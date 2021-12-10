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
                return string.Concat(Fabicante + " - " + Modelo);
            }
        }

        [Required(ErrorMessage = "Infromação Obrigatória")]
        [Display(Name ="Fabricante do item")]
        public string Fabicante { get; set; }

        [Required(ErrorMessage = "Infromação Obrigatória")]
        [Display(Name = "Modelo do item")]
        public string Modelo { get; set; }

    }
}
