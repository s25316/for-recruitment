using MAS05.DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS05.DatabaseLayer.Configurations
{
    internal class BeeEFConfiguration : IEntityTypeConfiguration<Bee>
    {
        public void Configure(EntityTypeBuilder<Bee> builder)
        {
            builder.ToTable("Pszczola");
            builder.HasKey(b => b.IdBee).HasName("Pszczola_pk");
            builder.Property(b => b.IdBee).UseIdentityColumn();

            builder.Property(b => b.Name).IsRequired().HasMaxLength(30)
                .HasColumnName("Imie").HasColumnType("nvarchar");
            builder.Property(b => b.BirthDate).IsRequired().HasDefaultValueSql("GETDATE()");

            Bee[] data = 
                { 
                new Bee { IdBee = 1, Name = "Bzzz", BirthDate = new DateOnly(2024,05,20) },
                new Bee { IdBee = 2, Name = "Bzzzaa", BirthDate = new DateOnly(2024,05,15) },
                new Bee { IdBee = 3, Name = "Bzzzuu", BirthDate = new DateOnly(2024,05,12) },
            }; 
            builder.HasData(data);
        }
    }
}
