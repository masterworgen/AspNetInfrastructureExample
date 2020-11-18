using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TBMMORPG.Infrastructure.Data.Interface;

namespace TBMMORPG.Infrastructure.Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseDomain
    {
        private readonly IDbContext _context;
        private DbSet<T> _entities;

        public EfRepository(IDbContext context)
        {
            _context = context;
        }

        protected virtual DbSet<T> Entities
        {
            get { return _entities ?? (_entities = _context.Set<T>()); }
        }

        public IQueryable<T> Table
        {
            get { return Entities; }
        }

        public IQueryable<T> TableNotTracking
        {
            get { return Entities.AsNoTracking(); }
        }
        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentException("entity");

            Entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentException("entity");

            _context.SaveChanges();
        }

        public void Delete(T entity, bool force = false)
        {
            if (entity == null)
                throw new ArgumentException("entity");

            if (force)
                Entities.Remove(entity);
            else
            {
                // Мы всегда уверены, что в таблице есть поле IsDeleted
                var fieldProperty = entity.GetType().GetProperty("IsDeleted");
                fieldProperty.SetValue(entity, true, null);
            }
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<T> entity)
        {
            if (entity == null)
                throw new ArgumentException("entity");

            Entities.AddRange(entity);

            _context.SaveChanges();
        }

        public void UpdateRange(IEnumerable<T> entity)
        {
            if (entity == null)
                throw new ArgumentException("entity");

            Entities.UpdateRange(entity);

            _context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<T> entities, bool force = false)
        {
            if (entities == null)
                throw new ArgumentException("entity");

            if (force)
                Entities.RemoveRange(entities);
            else
            {
                foreach (var entity in entities)
                {
                    // Мы всегда уверены, что в таблице есть поле IsDeleted
                    var fieldProperty = entity.GetType().GetProperty("IsDeleted");
                    fieldProperty.SetValue(entities, true, null);
                }
            }

            _context.SaveChanges();
        }
    }
}
