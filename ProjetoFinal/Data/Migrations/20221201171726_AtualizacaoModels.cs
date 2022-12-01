using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinal.Data.Migrations
{
    public partial class AtualizacaoModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisicoes_Produtos_produtoId",
                table: "Requisicoes");

            migrationBuilder.RenameColumn(
                name: "produtoId",
                table: "Requisicoes",
                newName: "ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Requisicoes_produtoId",
                table: "Requisicoes",
                newName: "IX_Requisicoes_ProdutoId");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "Requisicoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requisicoes_Produtos_ProdutoId",
                table: "Requisicoes",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisicoes_Produtos_ProdutoId",
                table: "Requisicoes");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "Requisicoes",
                newName: "produtoId");

            migrationBuilder.RenameIndex(
                name: "IX_Requisicoes_ProdutoId",
                table: "Requisicoes",
                newName: "IX_Requisicoes_produtoId");

            migrationBuilder.AlterColumn<int>(
                name: "produtoId",
                table: "Requisicoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Requisicoes_Produtos_produtoId",
                table: "Requisicoes",
                column: "produtoId",
                principalTable: "Produtos",
                principalColumn: "Id");
        }
    }
}
