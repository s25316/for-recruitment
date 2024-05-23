using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleApp09__EF__CdF_.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WykonwcaUtworu",
                columns: table => new
                {
                    MusiciansIdMusician = table.Column<int>(type: "int", nullable: false),
                    SongsIdSong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WykonwcaUtworu", x => new { x.MusiciansIdMusician, x.SongsIdSong });
                    table.ForeignKey(
                        name: "FK_WykonwcaUtworu_Muzyk_MusiciansIdMusician",
                        column: x => x.MusiciansIdMusician,
                        principalTable: "Muzyk",
                        principalColumn: "IdMuzyk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WykonwcaUtworu_Utwor_SongsIdSong",
                        column: x => x.SongsIdSong,
                        principalTable: "Utwor",
                        principalColumn: "IdUtwor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 1,
                column: "DataWydania",
                value: new DateTime(2024, 5, 4, 1, 30, 53, 723, DateTimeKind.Local).AddTicks(2739));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 2,
                column: "DataWydania",
                value: new DateTime(2024, 5, 4, 1, 30, 53, 723, DateTimeKind.Local).AddTicks(2786));

            migrationBuilder.CreateIndex(
                name: "IX_WykonwcaUtworu_SongsIdSong",
                table: "WykonwcaUtworu",
                column: "SongsIdSong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WykonwcaUtworu");

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 1,
                column: "DataWydania",
                value: new DateTime(2024, 5, 4, 1, 16, 44, 464, DateTimeKind.Local).AddTicks(1311));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 2,
                column: "DataWydania",
                value: new DateTime(2024, 5, 4, 1, 16, 44, 464, DateTimeKind.Local).AddTicks(1352));
        }
    }
}
