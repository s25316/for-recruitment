using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdministrativeType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Depth = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AdministrativeType_Pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Regon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOurClient = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Company_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ContactStatus_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Country_Pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("DocumentType_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Street",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    IdSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Street_Pk", x => x.Id);
                    table.ForeignKey(
                        name: "AdministrativeType_Street",
                        column: x => x.TypeId,
                        principalTable: "AdministrativeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UniversityType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("University_pk", x => x.Id);
                    table.ForeignKey(
                        name: "University_Company",
                        column: x => x.Id,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoryOfContact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReaded = table.Column<bool>(type: "bit", nullable: false),
                    FirstMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("HistoryOfContact_pk", x => x.Id);
                    table.ForeignKey(
                        name: "HistoryOfContact_ContactStatus",
                        column: x => x.IdStatus,
                        principalTable: "ContactStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdministrativeDivision",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    SourceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AdministrativeDivision_Pk", x => x.Id);
                    table.ForeignKey(
                        name: "AdministrativeType_AdministrativeDivision",
                        column: x => x.TypeId,
                        principalTable: "AdministrativeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Country_AdministrativeDivision",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Collocation",
                columns: table => new
                {
                    DivisionId = table.Column<long>(type: "bigint", nullable: false),
                    StreetId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Collocation_Pk", x => new { x.StreetId, x.DivisionId });
                    table.ForeignKey(
                        name: "Collocation_AdministrativeDivision",
                        column: x => x.DivisionId,
                        principalTable: "AdministrativeDivision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Collocation_Street",
                        column: x => x.StreetId,
                        principalTable: "Street",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DivisionId = table.Column<long>(type: "bigint", nullable: false),
                    StreetId = table.Column<long>(type: "bigint", nullable: false),
                    BuldingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Address_pk", x => x.Id);
                    table.ForeignKey(
                        name: "Address_Collocation",
                        columns: x => new { x.StreetId, x.DivisionId },
                        principalTable: "Collocation",
                        principalColumns: new[] { "StreetId", "DivisionId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Depratment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Depratment_pk", x => x.Id);
                    table.ForeignKey(
                        name: "Address_Depratment",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastPositionPep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Person_pk", x => x.Id);
                    table.ForeignKey(
                        name: "Address_Person",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoryOfContactCompany",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepratmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("HistoryOfContactCompany_pk", x => x.Id);
                    table.ForeignKey(
                        name: "HistoryOfContactCompany_Company",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "HistoryOfContactCompany_Depratment",
                        column: x => x.DepratmentId,
                        principalTable: "Depratment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "HistoryOfContact_HistoryOfContactCompany",
                        column: x => x.Id,
                        principalTable: "HistoryOfContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Document_pk", x => x.Id);
                    table.ForeignKey(
                        name: "Document_DocumentType",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Document_Person",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Competences = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Employee_pk", x => x.Id);
                    table.ForeignKey(
                        name: "Employee_Person",
                        column: x => x.Id,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Client_pk", x => x.Id);
                    table.ForeignKey(
                        name: "Client_Employee",
                        column: x => x.EmploeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Client_Person",
                        column: x => x.Id,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EducationHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fild = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Corse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UniversityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EducationHistory_pk", x => x.Id);
                    table.ForeignKey(
                        name: "EducationHistory_Employee",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "EducationHistory_University",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDepratment",
                columns: table => new
                {
                    IdApplicationDatabaseModelsDepratment = table.Column<Guid>(name: "IdApplication.Database.Models.Depratment", type: "uniqueidentifier", nullable: false),
                    IdApplicationDatabaseModelsPersonPartEmployee = table.Column<Guid>(name: "IdApplication.Database.Models.PersonPart.Employee", type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDepratment", x => new { x.IdApplicationDatabaseModelsDepratment, x.IdApplicationDatabaseModelsPersonPartEmployee });
                    table.ForeignKey(
                        name: "FK_EmployeeDepratment_Depratment_IdApplication.Database.Models.Depratment",
                        column: x => x.IdApplicationDatabaseModelsDepratment,
                        principalTable: "Depratment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeDepratment_Employee_IdApplication.Database.Models.PersonPart.Employee",
                        column: x => x.IdApplicationDatabaseModelsPersonPartEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EmploymentHistory_pk", x => x.Id);
                    table.ForeignKey(
                        name: "EmploymentHistory_Company",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "EmploymentHistory_Employee",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManagerDepratment",
                columns: table => new
                {
                    IdApplicationDatabaseModelsDepratment = table.Column<Guid>(name: "IdApplication.Database.Models.Depratment", type: "uniqueidentifier", nullable: false),
                    IdApplicationDatabaseModelsPersonPartEmployee = table.Column<Guid>(name: "IdApplication.Database.Models.PersonPart.Employee", type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerDepratment", x => new { x.IdApplicationDatabaseModelsDepratment, x.IdApplicationDatabaseModelsPersonPartEmployee });
                    table.ForeignKey(
                        name: "FK_ManagerDepratment_Depratment_IdApplication.Database.Models.Depratment",
                        column: x => x.IdApplicationDatabaseModelsDepratment,
                        principalTable: "Depratment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManagerDepratment_Employee_IdApplication.Database.Models.PersonPart.Employee",
                        column: x => x.IdApplicationDatabaseModelsPersonPartEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoryOfContactClient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepratmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("HistoryOfContactClient_pk", x => x.Id);
                    table.ForeignKey(
                        name: "HistoryOfContactClient_Client",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "HistoryOfContactClient_Depratment",
                        column: x => x.DepratmentId,
                        principalTable: "Depratment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "HistoryOfContact_HistoryOfContactClient",
                        column: x => x.Id,
                        principalTable: "HistoryOfContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ContactStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Utworzone" },
                    { 2, "WyslaneNieOdczytane" },
                    { 3, "Anulowane" },
                    { 4, "Odzczytane" },
                    { 5, "OdzczytaneZaakceptowane" },
                    { 6, "OdzczytaneNieZaakaceptowane" },
                    { 7, "ZwroconeZaakceptowane" },
                    { 8, "ZwroconeNieZaakaceptowane" },
                    { 9, "Zakonczone" }
                });

            migrationBuilder.InsertData(
                table: "DocumentType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dowod Osobisty" },
                    { 2, "Paszport" },
                    { 3, "Karta Pobytu" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_StreetId_DivisionId",
                table: "Address",
                columns: new[] { "StreetId", "DivisionId" });

            migrationBuilder.CreateIndex(
                name: "IX_AdministrativeDivision_CountryId",
                table: "AdministrativeDivision",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AdministrativeDivision_TypeId",
                table: "AdministrativeDivision",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_EmploeeId",
                table: "Client",
                column: "EmploeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Collocation_DivisionId",
                table: "Collocation",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Depratment_AddressId",
                table: "Depratment",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_DocumentTypeId",
                table: "Document",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_PersonId",
                table: "Document",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationHistory_EmployeeId",
                table: "EducationHistory",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationHistory_UniversityId",
                table: "EducationHistory",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepratment_IdApplication.Database.Models.PersonPart.Employee",
                table: "EmployeeDepratment",
                column: "IdApplication.Database.Models.PersonPart.Employee");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentHistory_CompanyId",
                table: "EmploymentHistory",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentHistory_EmployeeId",
                table: "EmploymentHistory",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryOfContact_IdStatus",
                table: "HistoryOfContact",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryOfContactClient_ClientId",
                table: "HistoryOfContactClient",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryOfContactClient_DepratmentId",
                table: "HistoryOfContactClient",
                column: "DepratmentId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryOfContactCompany_CompanyId",
                table: "HistoryOfContactCompany",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryOfContactCompany_DepratmentId",
                table: "HistoryOfContactCompany",
                column: "DepratmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerDepratment_IdApplication.Database.Models.PersonPart.Employee",
                table: "ManagerDepratment",
                column: "IdApplication.Database.Models.PersonPart.Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddressId",
                table: "Person",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Street_TypeId",
                table: "Street",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "EducationHistory");

            migrationBuilder.DropTable(
                name: "EmployeeDepratment");

            migrationBuilder.DropTable(
                name: "EmploymentHistory");

            migrationBuilder.DropTable(
                name: "HistoryOfContactClient");

            migrationBuilder.DropTable(
                name: "HistoryOfContactCompany");

            migrationBuilder.DropTable(
                name: "ManagerDepratment");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "University");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "HistoryOfContact");

            migrationBuilder.DropTable(
                name: "Depratment");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "ContactStatus");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Collocation");

            migrationBuilder.DropTable(
                name: "AdministrativeDivision");

            migrationBuilder.DropTable(
                name: "Street");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "AdministrativeType");
        }
    }
}
