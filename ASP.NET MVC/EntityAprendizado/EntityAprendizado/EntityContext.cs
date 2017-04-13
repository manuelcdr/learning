using EntityAprendizado.Entidades;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAprendizado
{
    public class EntityContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Venda> Vendas { get; set; }

        public DbSet<ProdutoVenda> ProdutosVendas { get; set; }

        public DbSet<PessoaFisica> PessoasFisicas { get; set; }

        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DataSourceConnectionString"].ConnectionString;

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoVenda>().HasKey(pv => new { pv.ProdutoID, pv.VendaID });
            base.OnModelCreating(modelBuilder);
        }
    }
}
