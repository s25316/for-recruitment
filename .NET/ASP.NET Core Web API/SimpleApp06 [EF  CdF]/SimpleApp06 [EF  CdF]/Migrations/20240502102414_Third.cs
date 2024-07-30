using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleApp06__EF__CdF_.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SamochodOsoba",
                columns: table => new
                {
                    IdCar = table.Column<int>(type: "int", nullable: false),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    MainOwner = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CarPerson_pk", x => new { x.IdCar, x.IdPerson });
                    table.ForeignKey(
                        name: "CarPeople_Car",
                        column: x => x.IdCar,
                        principalTable: "Samochody",
                        principalColumn: "IdCar",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "CarPeople_Person",
                        column: x => x.IdPerson,
                        principalTable: "Osoba",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SamochodOsoba_IdPerson",
                table: "SamochodOsoba",
                column: "IdPerson");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SamochodOsoba");
        }
    }
}
