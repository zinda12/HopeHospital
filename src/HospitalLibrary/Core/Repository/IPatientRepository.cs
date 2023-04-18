using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface IPatientRepository : IEntityRepository<Patient>
    {
        public Patient Create(Patient p, List<Allergen> allers);
        IEnumerable<Patient> GetBySelectedDoctorId(int id);
        public Patient? GetByUserId(int userId);
    }
}
