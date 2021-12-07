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

        public string Nome { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Telefone ou Ramail")]
        [DataType(DataType.PhoneNumber)]
        public int Telefone { get; set; }

        [Display(Name ="E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
