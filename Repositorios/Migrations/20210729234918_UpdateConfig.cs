using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class UpdateConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCarrinho_Produtos_ProdutoId",
                table: "ItemCarrinho");

            migrationBuilder.DropIndex(
                name: "IX_ItemCarrinho_ProdutoId",
                table: "ItemCarrinho");

            migrationBuilder.DropIndex(
                name: "IX_Carrinhos_ClienteId",
                table: "Carrinhos");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "ItemCarrinho");

            migrationBuilder.AddColumn<int>(
                name: "ItensId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ItensId",
                table: "Produtos",
                column: "ItensId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrinhos_ClienteId",
                table: "Carrinhos",
                column: "ClienteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ItemCarrinho_ItensId",
                table: "Produtos",
                column: "ItensId",
                principalTable: "ItemCarrinho",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ItemCarrinho_ItensId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_ItensId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Carrinhos_ClienteId",
                table: "Carrinhos");

            migrationBuilder.DropColumn(
                name: "ItensId",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "ItemCarrinho",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarrinho_ProdutoId",
                table: "ItemCarrinho",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrinhos_ClienteId",
                table: "Carrinhos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCarrinho_Produtos_ProdutoId",
                table: "ItemCarrinho",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
