using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MAS05.Migrations
{
    /// <inheritdoc />
    public partial class Hand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateDeath",
                table: "Pszczola",
                type: "date",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PszczolaOchroniarz",
                columns: table => new
                {
                    IdBee = table.Column<int>(type: "int", nullable: false),
                    Sila = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PszczolaOchroniarz_pk", x => x.IdBee);
                    table.ForeignKey(
                        name: "PszczolaOchroniarz_Pszczola",
                        column: x => x.IdBee,
                        principalTable: "Pszczola",
                        principalColumn: "IdBee",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PszczolaWywiadowaca",
                columns: table => new
                {
                    IdBee = table.Column<int>(type: "int", nullable: false),
                    Dystans = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PszczolaWywiadowaca_pk", x => x.IdBee);
                    table.ForeignKey(
                        name: "PszczolaWywiadowaca_Pszczola",
                        column: x => x.IdBee,
                        principalTable: "Pszczola",
                        principalColumn: "IdBee",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PszczolkiDomPszczolka",
                columns: table => new
                {
                    IdBee = table.Column<int>(type: "int", nullable: false),
                    IdBeeHome = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateOnly>(type: "date", nullable: false),
                    DateTo = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PszczolkiDomPszczolka_pk", x => new { x.IdBee, x.IdBeeHome });
                    table.ForeignKey(
                        name: "PszczolkiDomPszczolka_Pszczolka",
                        column: x => x.IdBee,
                        principalTable: "Pszczola",
                        principalColumn: "IdBee",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PszczolkiDomPszczolka_PszczolkiDom",
                        column: x => x.IdBeeHome,
                        principalTable: "PszcołkiDomek",
                        principalColumn: "IdBeeHome",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "PszcołkiDomek",
                keyColumn: "IdBeeHome",
                keyValue: 3,
                column: "Nazwa",
                value: "Domek 3");

            migrationBuilder.UpdateData(
                table: "Pszczola",
                keyColumn: "IdBee",
                keyValue: 1,
                column: "DateDeath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pszczola",
                keyColumn: "IdBee",
                keyValue: 2,
                column: "DateDeath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pszczola",
                keyColumn: "IdBee",
                keyValue: 3,
                column: "DateDeath",
                value: null);

            migrationBuilder.InsertData(
                table: "PszczolaOchroniarz",
                columns: new[] { "IdBee", "Sila" },
                values: new object[,]
                {
                    { 1, 10 },
                    { 2, 15 }
                });

            migrationBuilder.InsertData(
                table: "PszczolaWywiadowaca",
                columns: new[] { "IdBee", "Dystans" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 3, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PszczolkiDomPszczolka_IdBeeHome",
                table: "PszczolkiDomPszczolka",
                column: "IdBeeHome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PszczolaOchroniarz");

            migrationBuilder.DropTable(
                name: "PszczolaWywiadowaca");

            migrationBuilder.DropTable(
                name: "PszczolkiDomPszczolka");

            migrationBuilder.DropColumn(
                name: "DateDeath",
                table: "Pszczola");

            migrationBuilder.UpdateData(
                table: "PszcołkiDomek",
                keyColumn: "IdBeeHome",
                keyValue: 3,
                column: "Nazwa",
                value: "Domek 1");
        }
    }
}
