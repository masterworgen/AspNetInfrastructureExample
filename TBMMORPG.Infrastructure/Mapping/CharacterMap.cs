using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBMMORPG.Infrastructure.Domain;

namespace TBMMORPG.Infrastructure.Mapping
{
    public class CharacterMap : IEntityTypeConfiguration<CharacterDomain>
    {
        public void Configure(EntityTypeBuilder<CharacterDomain> builder)
        {
            //builder.HasOne(q => q.User).WithMany(q => q.Characters);
            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            builder.ToTable("Character");
        }
    }
}
