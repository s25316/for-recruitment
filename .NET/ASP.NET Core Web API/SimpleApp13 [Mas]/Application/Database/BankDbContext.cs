using Application.Database.Models;
using Application.Database.Models.AddressPart;
using Application.Database.Models.CompanyPart;
using Application.Database.Models.ContactPart;
using Application.Database.Models.DocumentPart;
using Application.Database.Models.PersonPart;
using Application.Database.Models.UniversityPart;
using Microsoft.EntityFrameworkCore;

namespace Application.Database
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions options) : base(options)
        {
        }

        protected BankDbContext()
        {
        }
        //Adress Part
        public virtual DbSet<AdministrativeDivision> Divisions { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<Collocation> CollocationsDivisionsAndStreets { get; set; }
        public virtual DbSet<AdministrativeType> AdministrativeTypes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        //Person Part
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        //Document Part
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }

        //Companies And University Parts
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<EmploymentHistory> EmploymentHistories { get; set; }
        public virtual DbSet<EducationHistory> EducationHistories { get; set; }

        public virtual DbSet<Depratment> Depratments { get; set; }
        //Contact Part
        public virtual DbSet<ContactStatus> ContactStatuses { get; set; }
        public virtual DbSet<HistoryOfContact> HistoryOfContacts { get; set; }
        public virtual DbSet<HistoryOfContactClient> HistoryOfContactClients { get; set; }
        public virtual DbSet<HistoryOfContactCompany> HistoryOfContactCompanies { get; set; }


    }
}
