using EntityAprendizado.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAprendizado.Dao
{
    class CategoriaDao : BasicDao<Categoria>
    {
        public CategoriaDao() : base() { }

        public override Categoria GetById(int id)
        {
            return context.Categorias.FirstOrDefault(u => u.ID == id);
        }
    }
}
