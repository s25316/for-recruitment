using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleApp11__EF__CdF_JWT_.DataAccessLayer.Models;

namespace SimpleApp11__EF__CdF_JWT_.DataAccessLayer.Configurations
{
    public class UserEFConfiguration : IEntityTypeConfiguration<UserEFModel>
    {
        public void Configure(EntityTypeBuilder<UserEFModel> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id).HasName("User_pk");
            

            builder.Property(x => x.Passsword).HasMaxLength(int.MaxValue);
            builder.Property(x => x.Salt).HasMaxLength(int.MaxValue);
            builder.Property(x => x.Refresh).HasMaxLength(int.MaxValue);

            builder.HasAlternateKey(x => x.Email).HasName("User_Email_Unique");
        }
    }
}
