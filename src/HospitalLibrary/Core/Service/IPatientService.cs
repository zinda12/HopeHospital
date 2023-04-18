using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface IPatientService
    {
        public List<Patient> GetAll();
        public List<Patient> GetBySelectedDoctorId(int id);
        public Patient? GetById(int id);
        public Patient Create(Patient patient);
        public void Update(Patient patient);
        public void Delete(int id);
        public Patient CreateAndAddAllergens(Patient patient, List<Allergen> allers);
        public Patient GetByUserId(int userId);
    }
}
