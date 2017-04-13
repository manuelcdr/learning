using EntityAprendizado.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAprendizado.Dao 
{
    public class UsuarioDao : BasicDao<Usuario>
    {
        public UsuarioDao(EntityContext ctx) : base(ctx) {
        }


        public override Usuario GetById(int id)
        {
            return context.Usuarios.FirstOrDefault(u => u.ID == id);
        }
    }
}
