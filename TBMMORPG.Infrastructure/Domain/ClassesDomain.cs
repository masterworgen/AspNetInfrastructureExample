using System.Collections.Generic;
using TBMMORPG.Infrastructure.Data;

namespace TBMMORPG.Infrastructure.Domain
{
    public class ClassesDomain : BaseEntity, ISoftDeletable
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Constitution { get; set; }

        public List<SkillDomain> Skills { get; set; }
        public bool IsDeleted { get; set; }
    }
}
