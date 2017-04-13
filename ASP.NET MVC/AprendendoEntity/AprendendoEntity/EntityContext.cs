using AprendendoEntity.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoEntity
{
    public class EntityContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            

            modelBuilder.Build()
            base.OnModelCreating(modelBuilder);
        }

    }
}
