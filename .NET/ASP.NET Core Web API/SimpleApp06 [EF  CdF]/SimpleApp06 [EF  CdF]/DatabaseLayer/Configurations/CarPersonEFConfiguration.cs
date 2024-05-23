using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleApp06__EF__CdF_.DatabaseLayer.Configurations
{
    public class CarPersonEFConfiguration : IEntityTypeConfiguration<CarPerson>
    {
        public void Configure(EntityTypeBuilder<CarPerson> builder)
        {
            builder.ToTable("SamochodOsoba");
            builder.HasKey(c => new {c.IdCar, c.IdPerson}).HasName("CarPerson_pk");

            builder.HasOne(c => c.Car).WithMany(c => c.CarPeople).
                HasForeignKey(c => c.IdCar).HasConstraintName("CarPeople_Car").
                OnDelete(DeleteBehavior.Cascade); //Restrict
            builder.HasOne(c => c.Person).WithMany(c => c.CarPeople).
                HasForeignKey(c => c.IdPerson).HasConstraintName("CarPeople_Person").
                OnDelete(DeleteBehavior.Cascade);

            /*
              entity.HasMany(d => d.IdTrips).WithMany(p => p.IdCountries)
                .UsingEntity<Dictionary<string, object>>(
                    "CountryTrip",
                    r => r.HasOne<Trip>().WithMany()
                        .HasForeignKey("IdTrip")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Country_Trip_Trip"),
                    l => l.HasOne<Country>().WithMany()
                        .HasForeignKey("IdCountry")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Country_Trip_Country"),
                    j =>
                    {
                        j.HasKey("IdCountry", "IdTrip").HasName("Country_Trip_pk");
                        j.ToTable("Country_Trip");
                    });
             */
        }
    }
}
