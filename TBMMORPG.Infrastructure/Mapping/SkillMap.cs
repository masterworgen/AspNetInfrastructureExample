using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBMMORPG.Infrastructure.Domain;

namespace TBMMORPG.Infrastructure.Mapping
{
    public class SkillMap : IEntityTypeConfiguration<SkillDomain>
    {
        public void Configure(EntityTypeBuilder<SkillDomain> builder)
        {
            builder.ToTable("Skill");
        }
    }
}
