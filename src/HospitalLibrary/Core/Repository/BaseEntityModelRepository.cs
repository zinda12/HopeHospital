using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Core.Repository
{
    public class BaseEntityModelRepository<TEntity> : IEntityRepository<TEntity> where TEntity : BaseEntityModel
    {
        protected readonly HospitalDbContext _dbContext;

        public BaseEntityModelRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual List<TEntity> GetAll() => _dbContext.Set<TEntity>().ToList();

        public virtual TEntity GetById(int id) => _dbContext.Set<TEntity>().FirstOrDefault(e => e.Id == id);

        public virtual TEntity Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public virtual void Update(TEntity entity)
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

    }
}
