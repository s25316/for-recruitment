using Application.Database;
using Application.Database.Models;
using Application.Database.Models.AddressPart;
using Application.Database.Models.CompanyPart;
using Application.Database.Models.ContactPart;
using Application.Database.Models.DocumentPart;
using Application.Database.Models.PersonPart;
using Application.Database.Models.UniversityPart;
using Infrastructure.Database.EntityConfigurations;
using Infrastructure.Database.EntityConfigurations.AddressPart;
using Infrastructure.Database.EntityConfigurations.CompanyPart;
using Infrastructure.Database.EntityConfigurations.ContactPart;
using Infrastructure.Database.EntityConfigurations.DocumentPart;
using Infrastructure.Database.EntityConfigurations.PersonPart;
using Infrastructure.Database.EntityConfigurations.UniversityPart;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Database
{
    public class BankMsSqlDbContext : BankDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Adress Part
            modelBuilder.ApplyConfiguration<AdministrativeDivision>(new AdministrativeDivisionEFCofiguration());
            modelBuilder.ApplyConfiguration<Collocation>(new CollocationEFConfiguration());
            modelBuilder.ApplyConfiguration<AdministrativeType>(new AdministrativeTypeEFConfiguration());
            modelBuilder.ApplyConfiguration<Street>(new StreetEFConfiguration());
            modelBuilder.ApplyConfiguration<Country>(configuration: new CountryEFConfiguration());
            modelBuilder.ApplyConfiguration<Address>(configuration: new AddressEFConfiguration());

            //Person Part
            modelBuilder.ApplyConfiguration<Person>(configuration: new PersonEFConfiguration());
            modelBuilder.ApplyConfiguration<Employee>(configuration: new EmployeeEFConfiguration());
            modelBuilder.ApplyConfiguration<Client>(configuration: new ClientEFCOnfiguration());

            //Document Part
            modelBuilder.ApplyConfiguration<Document>(configuration: new DocumentEFConfiguration());
            modelBuilder.ApplyConfiguration<DocumentType>(configuration: new DocumentTypeEFConfiguration());

            //Company Part
            modelBuilder.ApplyConfiguration<Company>(configuration: new CompanyEFConfiguration());
            modelBuilder.ApplyConfiguration<EmploymentHistory>(configuration: new EmploymentHistoryEFConfiguration());

            //University Part
            modelBuilder.ApplyConfiguration<University>(configuration: new UniversityEFConfiguration());
            modelBuilder.ApplyConfiguration<EducationHistory>(configuration: new EducationHistoryEFConfiguration());

            //Department
            modelBuilder.ApplyConfiguration<Depratment>(configuration: new DepratmentEFConfiguration());

            //Contact
            modelBuilder.ApplyConfiguration<ContactStatus>(configuration: new ContactStatusEFConfiguration());
            modelBuilder.ApplyConfiguration<HistoryOfContact>(configuration: new HistoryOfContactEFConfiguration());
            modelBuilder.ApplyConfiguration<HistoryOfContactClient>(configuration: new HistoryOfContactClientEFConfiguration());
            modelBuilder.ApplyConfiguration<HistoryOfContactCompany>(configuration: new HistoryOfContactCompanyEFConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddUserSecrets<BankMsSqlDbContext>() // Pobierz konfigurację z User Secrets
                    .Build();

                var connectionString = configuration.GetConnectionString("DBString");
                optionsBuilder.UseSqlServer(connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
