using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteNewCon1.Migrations
{
    public partial class PopulaTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PontosTuristicos",
                columns: new[] { "Id", "Cidade", "DataCadastro", "Descricao", "Estado", "Localizacao", "Nome" },
                values: new object[] { 1, "Rio de Janeiro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.", "RJ", "Morro do Corcovado", "TESTE Cristo Redentor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PontosTuristicos",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
