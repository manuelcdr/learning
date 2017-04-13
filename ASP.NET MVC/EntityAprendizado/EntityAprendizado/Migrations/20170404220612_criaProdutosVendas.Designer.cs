using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using EntityAprendizado;

namespace EntityAprendizado.Migrations
{
    [DbContext(typeof(EntityContext))]
    [Migration("20170404220612_criaProdutosVendas")]
    partial class criaProdutosVendas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityAprendizado.Entidades.Categoria", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("EntityAprendizado.Entidades.Produto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoriaID");

                    b.Property<string>("Nome");

                    b.Property<double>("Preco");

                    b.Property<int>("Quantidade");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("EntityAprendizado.Entidades.ProdutoVenda", b =>
                {
                    b.Property<int>("ProdutoID");

                    b.Property<int>("VendaID");

                    b.HasKey("ProdutoID", "VendaID");
                });

            modelBuilder.Entity("EntityAprendizado.Entidades.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<string>("Senha");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("EntityAprendizado.Entidades.Venda", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UsuarioID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("EntityAprendizado.Entidades.Produto", b =>
                {
                    b.HasOne("EntityAprendizado.Entidades.Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaID");
                });

            modelBuilder.Entity("EntityAprendizado.Entidades.ProdutoVenda", b =>
                {
                    b.HasOne("EntityAprendizado.Entidades.Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoID");

                    b.HasOne("EntityAprendizado.Entidades.Venda")
                        .WithMany()
                        .HasForeignKey("VendaID");
                });

            modelBuilder.Entity("EntityAprendizado.Entidades.Venda", b =>
                {
                    b.HasOne("EntityAprendizado.Entidades.Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID");
                });
        }
    }
}
