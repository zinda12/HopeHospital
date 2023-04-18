using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface IEntityRepository<TEntity> where TEntity : BaseEntityModel
    {
        public List<TEntity> GetAll();
        public TEntity GetById(int id);
        public TEntity Create(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(int id);
    }
}
