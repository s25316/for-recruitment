using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleApp06__EF__CdF_.Migrations
{
    /// <inheritdoc />
    public partial class Hand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Osoba",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DrivingLicence = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Person_pk", x => x.IdPerson);
                });

            migrationBuilder.InsertData(
                table: "Osoba",
                columns: new[] { "IdPerson", "DrivingLicence", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, null, "John", "Reese" },
                    { 2, "ASD32", "Mark", "Snow" },
                    { 3, "AAAAA", "Harold", "Finch" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Osoba");
        }
    }
}
