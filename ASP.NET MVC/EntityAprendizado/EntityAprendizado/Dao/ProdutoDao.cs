using EntityAprendizado.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAprendizado.Dao
{
    class ProdutoDao : BasicDao<Produto>
    {
        public ProdutoDao() : base() { }

        public ProdutoDao(EntityContext ctx)
        {
            this.context = ctx;
        }

        public override Produto GetById(int id)
        {
            return context.Produtos.FirstOrDefault(u => u.ID == id);
        }
    }
}
