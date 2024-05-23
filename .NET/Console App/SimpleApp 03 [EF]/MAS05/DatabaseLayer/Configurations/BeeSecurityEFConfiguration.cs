using MAS05.DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS05.DatabaseLayer.Configurations
{
    internal class BeeSecurityEFConfiguration : IEntityTypeConfiguration<BeeSecurity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BeeSecurity> builder)
        {
            builder.ToTable("PszczolaOchroniarz");
            builder.HasKey(b => b.IdBee).HasName("PszczolaOchroniarz_pk");

            builder.Property(b => b.Power).IsRequired().HasColumnName("Sila");

            builder.HasOne(b => b.Bee).WithOne(b => b.BeeSecurity)
                .HasForeignKey<BeeSecurity>(b => b.IdBee).IsRequired()
                .HasConstraintName("PszczolaOchroniarz_Pszczola")
                .OnDelete(DeleteBehavior.Restrict);

            BeeSecurity[] data = { 
                new BeeSecurity { IdBee = 1, Power = 10 },
                new BeeSecurity { IdBee = 2, Power = 15 }
            }; 
            builder.HasData(data);
        }
    }
}
