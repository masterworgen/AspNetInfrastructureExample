using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBMMORPG.Infrastructure.Domain;

namespace TBMMORPG.Infrastructure.Mapping
{
    public class LevelMap : IEntityTypeConfiguration<LevelDomain>
    {
        public void Configure(EntityTypeBuilder<LevelDomain> builder)
        {
            builder.ToTable("Level");
        }
    }
}
