using HospitalLibrary.Core.Model;


namespace HospitalLibrary.Core.Service
{
    public interface IAllergenService
    {
        public List<Allergen> GetAll();
        public Allergen GetById(int id);
        public Allergen Create(Allergen allergen);
        public void Update(Allergen patient);
        public void Delete(int id);
    }
}
