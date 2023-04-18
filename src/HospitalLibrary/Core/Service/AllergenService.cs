using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Service
{
    public class AllergenService : IAllergenService
    {
        private readonly IAllergensRepository _allergenRepositroy;

        public AllergenService(IAllergensRepository allergenRepositroy)
        {
            _allergenRepositroy = allergenRepositroy;
        }
        public Allergen Create(Allergen allergen) => _allergenRepositroy.Create(allergen);

        public void Delete(int id) => _allergenRepositroy.Delete(id);
    
        public List<Allergen> GetAll() => _allergenRepositroy.GetAll();

        public Allergen GetById(int id) => _allergenRepositroy.GetById(id);
   
        public void Update(Allergen allergen) => _allergenRepositroy.Update(allergen);
    
        public List<Allergen> Transform (List<int> allergens)
        {
            List<Allergen> allers = new List<Allergen>();
            foreach(int a in allergens)
            {
                allers.Add(GetById(a));
            }
            return allers;
        }
    }
}
