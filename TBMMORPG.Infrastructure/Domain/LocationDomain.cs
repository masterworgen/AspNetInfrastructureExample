using TBMMORPG.Infrastructure.Data;

namespace TBMMORPG.Infrastructure.Domain
{
    public class LocationDomain : BaseEntity, ISoftDeletable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string WelcomeMessage { get; set; }
        public bool IsDeleted { get; set; }
    }
}
