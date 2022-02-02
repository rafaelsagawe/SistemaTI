using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTI.Models
{
    public class Local
    {
        [Key]
        public int idLocal { get; set; }

        [Display(Name = "Tipo")]
        public string localTipo { get; set; }

        public string Nome { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco 
        {
            get
            {
                return string.Concat(Logradouro + ", " + Numero + ", " + Bairro + ".");
            }
        }
       
        public string Logradouro { get; set; }

        [Display(Name ="Número")]
        public string Numero { get; set; }

        public string Bairro { get; set; }

        public int CEP { get; set; }

        [Display(Name = "Telefone ou Ramail")]
        [DataType(DataType.PhoneNumber)]
        public int Telefone { get; set; }

        [Display(Name ="E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
