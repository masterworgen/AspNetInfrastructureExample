namespace TBMMORPG.Infrastructure.Domain
{
    public interface ISoftDeletable
    {
        public bool IsDeleted { get; set; }
    }
}
