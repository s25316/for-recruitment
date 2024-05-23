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
    internal class BeeHomeAndBeeConfiguration : IEntityTypeConfiguration<BeeHomeAndBee>
    {
        public void Configure(EntityTypeBuilder<BeeHomeAndBee> builder)
        {
            builder.ToTable("PszczolkiDomPszczolka");
            builder.HasKey(p => new {p.IdBee,p.IdBeeHome}).HasName("PszczolkiDomPszczolka_pk");

            builder.HasOne(p => p.Bee).WithMany(p => p.BeeHomeAndBees)
                .HasForeignKey(p => p.IdBee).HasConstraintName("PszczolkiDomPszczolka_Pszczolka")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.BeeHome).WithMany(p => p.BeeHomeAndBees)
                .HasForeignKey(p => p.IdBeeHome).HasConstraintName("PszczolkiDomPszczolka_PszczolkiDom")
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
