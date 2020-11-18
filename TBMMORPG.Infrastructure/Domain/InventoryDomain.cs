using TBMMORPG.Infrastructure.Data;

namespace TBMMORPG.Infrastructure.Domain
{
    public class InventoryDomain : BaseEntity, ISoftDeletable
    {
        public bool IsEquipped { get; set; }
        public bool CanBeDropped { get; set; }

        public ItemDomain Item { get; set; }
        public int ItemId { get; set; }
        public CharacterDomain Character { get; set; }
        public int CharacterId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
