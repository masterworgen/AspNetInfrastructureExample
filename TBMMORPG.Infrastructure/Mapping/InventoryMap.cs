using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBMMORPG.Infrastructure.Domain;

namespace TBMMORPG.Infrastructure.Mapping
{
    public class InventoryMap : IEntityTypeConfiguration<InventoryDomain>
    {
        public void Configure(EntityTypeBuilder<InventoryDomain> builder)
        {
            builder.ToTable("Inventory");
        }
    }
}
