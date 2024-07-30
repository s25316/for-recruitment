using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleApp07__EF__CdF_.Migrations
{
    /// <inheritdoc />
    public partial class Hand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    IdMovie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    RelizeDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Film_pk", x => x.IdMovie);
                });

            migrationBuilder.CreateTable(
                name: "AktorFilm",
                columns: table => new
                {
                    IdActorMovie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdActor = table.Column<int>(type: "int", nullable: false),
                    IdMovie = table.Column<int>(type: "int", nullable: false),
                    CharacterName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AktorFilm_pk", x => x.IdActorMovie);
                    table.ForeignKey(
                        name: "ActorMovie_Actor",
                        column: x => x.IdActor,
                        principalTable: "Aktor",
                        principalColumn: "IdActor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ActorMovie_Movie",
                        column: x => x.IdMovie,
                        principalTable: "Film",
                        principalColumn: "IdMovie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Film",
                columns: new[] { "IdMovie", "Name", "RelizeDate" },
                values: new object[,]
                {
                    { 1, "GoldenEye", new DateOnly(1995, 12, 1) },
                    { 2, "Jutro nie umiera nigdy ", new DateOnly(1997, 1, 16) },
                    { 3, "Świat to za mało", new DateOnly(1999, 11, 8) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AktorFilm_IdActor",
                table: "AktorFilm",
                column: "IdActor");

            migrationBuilder.CreateIndex(
                name: "IX_AktorFilm_IdMovie",
                table: "AktorFilm",
                column: "IdMovie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AktorFilm");

            migrationBuilder.DropTable(
                name: "Film");
        }
    }
}
