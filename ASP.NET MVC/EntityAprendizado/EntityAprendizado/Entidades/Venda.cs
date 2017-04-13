using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAprendizado.Entidades
{
    public class Venda
    {
        public int ID { get; set; }
        public int UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual IList<ProdutoVenda> ProdutosVendas { get; set; }
    }
}
