using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBMMORPG.Infrastructure.Domain;

namespace TBMMORPG.Infrastructure.Mapping
{
    public class ItemMap : IEntityTypeConfiguration<ItemDomain>
    {
        public void Configure(EntityTypeBuilder<ItemDomain> builder)
        {
            builder.ToTable("Item");
        }
    }
}
