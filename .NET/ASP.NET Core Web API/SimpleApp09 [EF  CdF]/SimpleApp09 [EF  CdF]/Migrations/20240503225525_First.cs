using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleApp09__EF__CdF_.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Muzyk",
                columns: table => new
                {
                    IdMuzyk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Pseudonim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Muzyk_pk", x => x.IdMuzyk);
                });

            migrationBuilder.CreateTable(
                name: "Wytwornia",
                columns: table => new
                {
                    IdWytwornia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Wytwornia_pk", x => x.IdWytwornia);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaAlbumu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DataWydania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdLabel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Album_pk", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "Albums_Label",
                        column: x => x.IdLabel,
                        principalTable: "Wytwornia",
                        principalColumn: "IdWytwornia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Muzyk",
                columns: new[] { "IdMuzyk", "Imie", "Pseudonim", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "Andrzej", null, "Kwiatkowski" },
                    { 2, "Damian", "Cebula", "Cebulski" },
                    { 3, "Anna", null, "Kwiatkowska" }
                });

            migrationBuilder.InsertData(
                table: "Wytwornia",
                columns: new[] { "IdWytwornia", "Nazwa" },
                values: new object[,]
                {
                    { 1, "Warszawianka" },
                    { 2, "Głos Wrocławia" }
                });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "IdAlbum", "IdLabel", "NazwaAlbumu", "DataWydania" },
                values: new object[,]
                {
                    { 1, 1, "Syrenki", new DateTime(2024, 5, 4, 0, 55, 25, 213, DateTimeKind.Local).AddTicks(495) },
                    { 2, 1, "Nadwislanskie Szanty", new DateTime(2024, 5, 4, 0, 55, 25, 213, DateTimeKind.Local).AddTicks(552) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_IdLabel",
                table: "Album",
                column: "IdLabel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Muzyk");

            migrationBuilder.DropTable(
                name: "Wytwornia");
        }
    }
}
