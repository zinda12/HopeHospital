using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;


namespace HospitalLibrary.Core.Repository
{
    public class AllergensRepository : BaseEntityModelRepository<Allergen>, IAllergensRepository
    {
        public AllergensRepository(HospitalDbContext dbContext) : base(dbContext)
        {

        }
        public List<Allergen> GetAllergensByDtoId(List<int> ids) => _dbContext.Allergens.Where(a => ids.Contains(a.Id)).ToList();


    }
}
