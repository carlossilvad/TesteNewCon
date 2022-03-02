using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PontosTuristicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Localizacao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosTuristicos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PontosTuristicos",
                columns: new[] { "Id", "Cidade", "DataCadastro", "Descricao", "Estado", "Localizacao", "Nome" },
                values: new object[,]
                {
                    { 1, "Rio de Janeiro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.", "RJ", "Morro do Corcovado", "Cristo Redentor 1" },
                    { 2, "Rio de Janeiro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.", "RJ", "Morro do Corcovado", "Cristo Redentor 2" },
                    { 3, "Rio de Janeiro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.", "RJ", "Morro do Corcovado", "Cristo Redentor 3" },
                    { 4, "Rio de Janeiro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.", "RJ", "Morro do Corcovado", "Cristo Redentor 4" },
                    { 5, "Rio de Janeiro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.", "RJ", "Morro do Corcovado", "Cristo Redentor 5" },
                    { 6, "Rio de Janeiro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.", "RJ", "Morro do Corcovado", "Cristo Redentor 6" },
                    { 7, "Rio de Janeiro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.", "RJ", "Morro do Corcovado", "Cristo Redentor 7" },
                    { 8, "Rio de Janeiro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.", "RJ", "Morro do Corcovado", "Cristo Redentor 8" },
                    { 9, "Rio de Janeiro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.", "RJ", "Morro do Corcovado", "Cristo Redentor 9" },
                    { 10, "Rio de Janeiro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.", "RJ", "Morro do Corcovado", "Cristo Redentor 10" },
                    { 11, "Rio de Janeiro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.", "RJ", "Morro do Corcovado", "Cristo Redentor 11" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PontosTuristicos");
        }
    }
}
