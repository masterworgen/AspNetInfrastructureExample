using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBMMORPG.Infrastructure.Domain;

namespace TBMMORPG.Infrastructure.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserDomain>
    {
        public void Configure(EntityTypeBuilder<UserDomain> builder)
        {
            builder.ToTable("User");
            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}
