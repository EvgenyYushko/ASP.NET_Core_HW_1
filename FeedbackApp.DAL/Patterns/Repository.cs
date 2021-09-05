using FeedbackApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackApp.DAL.Patterns
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApDbContext _db;

        public Repository(ApDbContext context)
        {
            _db = context;
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _db.Set<TEntity>().FindAsync(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _db.Set<TEntity>() /*.AsNoTracking()*/;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
            await Save();
            return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _db.Set<TEntity>().Remove(entity);
            await Save();
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            try
            {
                var newEntity = await _db.Set<TEntity>().AddAsync(entity);
                await Save();
                return newEntity.Entity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}