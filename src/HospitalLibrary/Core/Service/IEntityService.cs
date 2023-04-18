using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface IEntityService<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        T Create(T entity);
        void Update(int id, T entity);
        void Delete(int id);
    }
}
