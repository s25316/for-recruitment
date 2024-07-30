using Microsoft.EntityFrameworkCore;
using SimpleApp09__EF__CdF_.DatabaseLayer.Models;

namespace SimpleApp09__EF__CdF_.DatabaseLayer.Configurations
{
    public class LabelEFConfiguration : IEntityTypeConfiguration<Label>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Label> builder)
        {
            builder.ToTable("Wytwornia");
            builder.HasKey(t => t.IdLabel).HasName("Wytwornia_pk");
            builder.Property(t => t.IdLabel).UseIdentityColumn().HasColumnName("IdWytwornia");

            builder.Property(t => t.Name).IsRequired().HasMaxLength(50)
                .HasColumnType("nvarchar").HasColumnName("Nazwa");

            Label[] data = 
                { 
                new Label { IdLabel = 1, Name = "Warszawianka"},
                new Label { IdLabel = 2, Name = "Głos Wrocławia"},
            }; 
            builder.HasData(data);
        }
    }
}
