using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface IAllergensRepository : IEntityRepository<Allergen>
    {
        public List<Allergen> GetAllergensByDtoId(List<int> ids);
    }
}
