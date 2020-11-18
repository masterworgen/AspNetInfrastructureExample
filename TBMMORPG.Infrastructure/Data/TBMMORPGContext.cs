using System;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TBMMORPG.Infrastructure.Data.Interface;
using TBMMORPG.Infrastructure.Domain;

namespace TBMMORPG.Infrastructure.Data
{
    public class TBMMORPGContext : DbContext, IDbContext
    {
        private const string _isDeletedProperty = "IsDeleted";
        private static readonly MethodInfo _propertyMethod = typeof(EF).GetMethod(nameof(EF.Property), BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(typeof(bool));

        public TBMMORPGContext(DbContextOptions<TBMMORPGContext> options)
            : base(options)
        {
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : BaseDomain => base.Set<TEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(entity.ClrType))
                {
                    entity.AddProperty(_isDeletedProperty, typeof(bool));

                    modelBuilder
                        .Entity(entity.ClrType)
                        .HasQueryFilter(GetIsDeletedRestriction(entity.ClrType));
                }
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TBMMORPGContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
        private static LambdaExpression GetIsDeletedRestriction(Type type)
        {
            var parm = Expression.Parameter(type, "it");
            var prop = Expression.Call(_propertyMethod, parm, Expression.Constant(_isDeletedProperty));
            var condition = Expression.MakeBinary(ExpressionType.Equal, prop, Expression.Constant(false));
            var lambda = Expression.Lambda(condition, parm);
            return lambda;
        }
    }
}
