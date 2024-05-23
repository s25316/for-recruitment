using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MAS05.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PszcołkiDomek",
                columns: table => new
                {
                    IdBeeHome = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MaxSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PszcołkiDomek_pk", x => x.IdBeeHome);
                });

            migrationBuilder.CreateTable(
                name: "Pszczola",
                columns: table => new
                {
                    IdBee = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pszczola_pk", x => x.IdBee);
                });

            migrationBuilder.InsertData(
                table: "PszcołkiDomek",
                columns: new[] { "IdBeeHome", "MaxSize", "Nazwa" },
                values: new object[,]
                {
                    { 1, 30000, "Domek 1" },
                    { 2, 60000, "Domek 2" },
                    { 3, 45000, "Domek 1" }
                });

            migrationBuilder.InsertData(
                table: "Pszczola",
                columns: new[] { "IdBee", "BirthDate", "Imie" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 5, 20), "Bzzz" },
                    { 2, new DateOnly(2024, 5, 15), "Bzzzaa" },
                    { 3, new DateOnly(2024, 5, 12), "Bzzzuu" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PszcołkiDomek");

            migrationBuilder.DropTable(
                name: "Pszczola");
        }
    }
}
