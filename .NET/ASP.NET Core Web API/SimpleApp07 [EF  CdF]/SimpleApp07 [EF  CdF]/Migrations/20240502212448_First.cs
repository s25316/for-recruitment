using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleApp07__EF__CdF_.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aktor",
                columns: table => new
                {
                    IdActor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Aktor_pk", x => x.IdActor);
                });

            migrationBuilder.InsertData(
                table: "Aktor",
                columns: new[] { "IdActor", "Name", "Nickname", "Surname" },
                values: new object[,]
                {
                    { 1, "Frank", "Punisher", "Castle" },
                    { 2, "Billy", "Jigsaw", "Russo" },
                    { 3, "Caren", null, "Page" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aktor");
        }
    }
}
