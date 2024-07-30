using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleApp11__EF__CdF_JWT_.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Passsword = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Refresh = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    DeactivationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_pk", x => x.Id);
                    table.UniqueConstraint("User_Email_Unique", x => x.Email);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
