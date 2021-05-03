using BerylCalendar.Data.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerylCalendar.Data.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext ctx)
        {
            _context = ctx;
            _dbSet = _context.Set<TEntity>();   // must do it this way because we don't have a "navigation property" to use
        }

        // Find by ID assuming it's the PK and is an int
        public virtual async Task<TEntity> FindByIdAsync(int id)
        {
            TEntity entity = await _dbSet.FindAsync(id);
            return entity;  // null if not found
        }

        public virtual async Task<bool> ExistsAsync(int id)
        {
            return await FindByIdAsync(id) != null;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual async Task<TEntity> AddOrUpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
                throw new ArgumentNullException("Entity must not be null to add or update");
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
            }
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new Exception("Entity to delete was null");
            }
            else
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
            return;
        }

        public virtual async Task DeleteByIdAsync(int id)
        {
            await DeleteAsync(await FindByIdAsync(id));
            return;
        }
    }
}