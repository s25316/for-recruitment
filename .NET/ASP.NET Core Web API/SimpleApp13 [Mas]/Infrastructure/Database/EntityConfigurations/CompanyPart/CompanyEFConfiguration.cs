using Application.Database.Models.CompanyPart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations.CompanyPart
{
    public class CompanyEFConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable(nameof(Company));
            builder.HasKey(t => t.Id).HasName($"{nameof(Company)}_pk");
        }
    }
}
