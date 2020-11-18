using Microsoft.EntityFrameworkCore;

namespace TBMMORPG.Infrastructure.Data.Interface
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseDomain;

        int SaveChanges();
    }
}
