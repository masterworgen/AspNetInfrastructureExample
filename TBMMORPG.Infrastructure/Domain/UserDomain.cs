using System;
using System.Collections.Generic;
using TBMMORPG.Infrastructure.Data;

namespace TBMMORPG.Infrastructure.Domain
{
    public class UserDomain : BaseEntity, ISoftDeletable
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime LastAction { get; set; }
        public List<CharacterDomain> Characters { get; set; }
        public bool IsDeleted { get; set; }
    }
}
