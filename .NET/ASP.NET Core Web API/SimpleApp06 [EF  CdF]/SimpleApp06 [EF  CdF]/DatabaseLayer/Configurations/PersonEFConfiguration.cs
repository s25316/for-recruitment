using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleApp06__EF__CdF_.DatabaseLayer.Configurations
{
    public class PersonEFConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Osoba");//Table Name
            builder.HasKey(p => p.IdPerson).HasName("Person_pk"); //PK

            //entity.Property(e => e.IdCountry).ValueGeneratedNever();
            builder.Property(p => p.IdPerson).UseIdentityColumn();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30).HasColumnType("nvarchar");
            builder.Property(p => p.Surname).IsRequired().HasMaxLength(40).HasColumnType("nvarchar");
            builder.Property(p => p.DrivingLicence).HasMaxLength(5).HasColumnType("nvarchar");

            Person[] people =
                { 
                new Person { IdPerson = 1, Name = "John", Surname = "Reese", DrivingLicence = null},
                new Person { IdPerson = 2, Name = "Mark", Surname = "Snow", DrivingLicence = "ASD32"},
                new Person { IdPerson = 3, Name = "Harold", Surname = "Finch", DrivingLicence = "AAAAA"},
            }; 
            builder.HasData(people);
        }
    }
}
