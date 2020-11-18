using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBMMORPG.Infrastructure.Domain;

namespace TBMMORPG.Infrastructure.Mapping
{
    public class ClassesMap : IEntityTypeConfiguration<ClassesDomain>
    {
        public void Configure(EntityTypeBuilder<ClassesDomain> builder)
        {
            builder.ToTable("Classes");
        }
    }
}
