using TBMMORPG.Infrastructure.Data;

namespace TBMMORPG.Infrastructure.Domain
{
    public class LevelDomain : BaseEntity, ISoftDeletable
    {
        public ushort ExperienceToLevelUp { get; set; }
        public bool IsDeleted { get; set; }
    }
}
