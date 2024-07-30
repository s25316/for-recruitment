using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleApp09__EF__CdF_.Migrations
{
    /// <inheritdoc />
    public partial class Fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WykonwcaUtworu_Muzyk_MusiciansIdMusician",
                table: "WykonwcaUtworu");

            migrationBuilder.DropForeignKey(
                name: "FK_WykonwcaUtworu_Utwor_SongsIdSong",
                table: "WykonwcaUtworu");

            migrationBuilder.RenameColumn(
                name: "SongsIdSong",
                table: "WykonwcaUtworu",
                newName: "IdUtwor");

            migrationBuilder.RenameColumn(
                name: "MusiciansIdMusician",
                table: "WykonwcaUtworu",
                newName: "IdMuzyk");

            migrationBuilder.RenameIndex(
                name: "IX_WykonwcaUtworu_SongsIdSong",
                table: "WykonwcaUtworu",
                newName: "IX_WykonwcaUtworu_IdUtwor");

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 1,
                column: "DataWydania",
                value: new DateTime(2024, 5, 4, 1, 51, 33, 375, DateTimeKind.Local).AddTicks(8267));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 2,
                column: "DataWydania",
                value: new DateTime(2024, 5, 4, 1, 51, 33, 375, DateTimeKind.Local).AddTicks(8316));

            migrationBuilder.AddForeignKey(
                name: "FK_WykonwcaUtworu_Muzyk_IdMuzyk",
                table: "WykonwcaUtworu",
                column: "IdMuzyk",
                principalTable: "Muzyk",
                principalColumn: "IdMuzyk",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WykonwcaUtworu_Utwor_IdUtwor",
                table: "WykonwcaUtworu",
                column: "IdUtwor",
                principalTable: "Utwor",
                principalColumn: "IdUtwor",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WykonwcaUtworu_Muzyk_IdMuzyk",
                table: "WykonwcaUtworu");

            migrationBuilder.DropForeignKey(
                name: "FK_WykonwcaUtworu_Utwor_IdUtwor",
                table: "WykonwcaUtworu");

            migrationBuilder.RenameColumn(
                name: "IdUtwor",
                table: "WykonwcaUtworu",
                newName: "SongsIdSong");

            migrationBuilder.RenameColumn(
                name: "IdMuzyk",
                table: "WykonwcaUtworu",
                newName: "MusiciansIdMusician");

            migrationBuilder.RenameIndex(
                name: "IX_WykonwcaUtworu_IdUtwor",
                table: "WykonwcaUtworu",
                newName: "IX_WykonwcaUtworu_SongsIdSong");

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

            migrationBuilder.AddForeignKey(
                name: "FK_WykonwcaUtworu_Muzyk_MusiciansIdMusician",
                table: "WykonwcaUtworu",
                column: "MusiciansIdMusician",
                principalTable: "Muzyk",
                principalColumn: "IdMuzyk",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WykonwcaUtworu_Utwor_SongsIdSong",
                table: "WykonwcaUtworu",
                column: "SongsIdSong",
                principalTable: "Utwor",
                principalColumn: "IdUtwor",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
