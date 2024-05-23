using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleApp06__EF__CdF_.DatabaseLayer.Configurations
{
    public class CarEFConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Samochody");
            builder.HasKey(c => c.IdCar).HasName("Car_pk");

            builder.Property(c => c.IdCar).UseIdentityColumn();
            builder.Property(c => c.Make).IsRequired().HasMaxLength(15).HasColumnType("nvarchar");

            Car[] cars = 
                { 
                new Car { IdCar = 1 , Make = "Poland", PropductionYear = 1990},
                new Car { IdCar = 2 , Make = "Germany", PropductionYear = 1991}
            }; 
            builder.HasData(cars);
        }
    }
}
