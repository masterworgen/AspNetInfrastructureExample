using TBMMORPG.Infrastructure.Data;
using TBMMORPG.Infrastructure.Enums;

namespace TBMMORPG.Infrastructure.Domain
{
    public class ItemDomain : BaseEntity, ISoftDeletable
    {
        public EItemType ItemType { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Def { get; set; }
        public int AttackSpeed { get; set; }
        public float CriticalChance { get; set; }
        public bool IsDeleted { get; set; }
    }
}
