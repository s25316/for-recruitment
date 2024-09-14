using Application.Database.Models.PersonPart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations.PersonPart
{
    public class PersonEFConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable(nameof(Person));
            builder.HasKey(p => p.Id).HasName($"{nameof(Person)}_pk");
        }
    }
}
