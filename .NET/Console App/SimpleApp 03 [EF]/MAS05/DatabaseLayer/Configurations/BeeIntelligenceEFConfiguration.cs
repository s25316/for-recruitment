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
    internal class BeeIntelligenceEFConfiguration : IEntityTypeConfiguration<BeeIntelligence>
    {
        public void Configure(EntityTypeBuilder<BeeIntelligence> builder)
        {
            builder.ToTable("PszczolaWywiadowaca");
            builder.HasKey(b => b.IdBee).HasName("PszczolaWywiadowaca_pk");

            builder.Property(b => b.Distance).IsRequired().HasColumnName("Dystans");

            builder.HasOne(b => b.Bee).WithOne(b => b.BeeIntelligence)
                .HasForeignKey<BeeIntelligence>(b => b.IdBee)
                .HasConstraintName("PszczolaWywiadowaca_Pszczola")
                .OnDelete(DeleteBehavior.Restrict);

            BeeIntelligence[] data = { 
                new BeeIntelligence { IdBee = 2, Distance = 3 },
                new BeeIntelligence { IdBee = 3, Distance = 5 },
            }; 
            builder.HasData(data);
        }
    }
}
