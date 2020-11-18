using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBMMORPG.Infrastructure.Domain;

namespace TBMMORPG.Infrastructure.Mapping
{
    public class LocationMap : IEntityTypeConfiguration<LocationDomain>
    {
        public void Configure(EntityTypeBuilder<LocationDomain> builder)
        {
            builder.ToTable("Location");
        }
    }
}
