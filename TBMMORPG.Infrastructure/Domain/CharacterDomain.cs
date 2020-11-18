using System.Collections.Generic;
using TBMMORPG.Infrastructure.Data;
using TBMMORPG.Infrastructure.Enums;

namespace TBMMORPG.Infrastructure.Domain
{
    public class CharacterDomain : BaseEntity, ISoftDeletable
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public ushort Experience { get; set; }
        public ushort Level { get; set; }
        public int AttackSpeed { get; set; }
        public float CriticalChance { get; set; }
        public ushort Hp { get; set; }
        public ushort MaxHp { get; set; }
        public int RegenHp { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Constitution { get; set; }
        public EUserRole Role { get; set; } = EUserRole.User;
        
        public virtual UserDomain User { get; set; }
        public int UserId { get; set; }
        public virtual ClassesDomain Class { get; set; }
        public int ClassId { get; set; }
        public List<SkillDomain> Skills { get; set; }
        public List<InventoryDomain> Inventory { get; set; }
        public bool IsDeleted { get; set; }
    }
}
