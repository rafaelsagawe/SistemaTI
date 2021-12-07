using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTI.Models
{
    public class Sistema
    {
        [Key]
        public int IdSistema { get; set; }

        [Display(Name = "Nome do sistema")]
        public string NomeSistema { get; set; }

        [Display(Name = "Nome da Plataforma")]
        public string NomePlataforma { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Acesso")]
        [DataType(DataType.Url)] // Gera url na tela index
        public string Acesso { get; set; }

        [Display(Name = "Codigo fonte")]
        public string CodigoFonte { get; set; }

        [Display(Name = "Linguagem")]
        public string Linguagem { get; set; }

        [Display(Name = "Banco de Dados")]
        public string BandoDados { get; set; }

        [Display(Name = "Documentação")]
        public string Documentacao { get; set; }

        [Display(Name = "Hospedagem")]
        public string Hospedagem { get; set; }

        [Display(Name = "Clientes")]
        public string Clientes { get; set; }

        [Display(Name = "Estado de Desenvolvimento")]
        public string EstadoDesenvolvimento { get; set; }

    }
}
