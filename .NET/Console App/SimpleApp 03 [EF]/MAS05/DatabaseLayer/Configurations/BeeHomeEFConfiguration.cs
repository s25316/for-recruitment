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
    internal class BeeHomeEFConfiguration : IEntityTypeConfiguration<BeeHome>
    {
        public void Configure(EntityTypeBuilder<BeeHome> builder)
        {
            builder.ToTable("PszcołkiDomek");
            builder.HasKey(b => b.IdBeeHome).HasName("PszcołkiDomek_pk");
            builder.Property(b => b.IdBeeHome).UseIdentityColumn();

            builder.Property(b => b.Name).IsRequired().HasMaxLength(30)
                .HasColumnName("Nazwa").HasColumnType("nvarchar");

            BeeHome[] data = 
                { 
                new BeeHome { IdBeeHome = 1, Name = "Domek 1", MaxSize = 30000 },
                new BeeHome { IdBeeHome = 2, Name = "Domek 2", MaxSize = 60000 },
                new BeeHome { IdBeeHome = 3, Name = "Domek 3", MaxSize = 45000 },
            }; 
            builder.HasData(data);  
        }
    }
}
