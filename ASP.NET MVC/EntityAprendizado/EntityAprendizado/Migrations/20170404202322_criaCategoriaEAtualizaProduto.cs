using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace EntityAprendizado.Migrations
{
    public partial class criaCategoriaEAtualizaProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.ID);
                });
            migrationBuilder.AddColumn<int>(
                name: "CategoriaID",
                table: "Produto",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Categoria_CategoriaID",
                table: "Produto",
                column: "CategoriaID",
                principalTable: "Categoria",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Produto_Categoria_CategoriaID", table: "Produto");
            migrationBuilder.DropColumn(name: "CategoriaID", table: "Produto");
            migrationBuilder.DropTable("Categoria");
        }
    }
}
