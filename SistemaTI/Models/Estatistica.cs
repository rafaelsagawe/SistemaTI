using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/* Esta model terá  função de registar o estoque de suprimentos dos equipamentos: toner, cilindros e etc;
 *  Deve retonar o modelo da impressora com a contagem de similares
 */
namespace SistemaTI.Models
{
    public class ItensProcessoEntrgue
    {
        public int ItemEntregue { get; set; }

        public int ContagemItem { get; set; }

        public string NomeItem { get; set; }

    }
}
