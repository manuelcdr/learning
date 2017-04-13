using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAprendizado.Dao
{
    public abstract class BasicDao<TEntity> where TEntity : class
    {
        protected EntityContext context;

        public BasicDao()
        {
            this.context = new EntityContext();
        }

        public BasicDao(EntityContext ctx)
        {
            this.context = ctx;
        }

        public virtual void Adicionar(TEntity objeto)
        {
            this.context.Add(objeto);
            this.SaveChanges();
        }

        public virtual void Remover(TEntity objeto)
        {
            this.context.Remove(objeto);
            this.SaveChanges();
        }

        public abstract TEntity GetById(int id);

        public virtual void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
