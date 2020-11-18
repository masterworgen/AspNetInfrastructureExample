using TBMMORPG.Infrastructure.Data;

namespace TBMMORPG.Infrastructure.Domain
{
    public class SkillDomain : BaseEntity, ISoftDeletable
    {
        public string Description { get; set; }

        public ClassesDomain Classes { get; set; }
        public int ClassesId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
