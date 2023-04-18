using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto;

namespace HospitalLibrary.Core.Repository
{
    public class PatientRepository : BaseEntityModelRepository<Patient>, IPatientRepository
    {
        public PatientRepository(HospitalDbContext dbContext) : base(dbContext)
        {

        }

        public Patient Create(Patient p, List<Allergen> allers)
        {
            p.Allergens = allers;
            return Create(p);

        }
        public IEnumerable<Patient> GetBySelectedDoctorId(int id)
        {
            return _dbContext.Patients.Where(p => p.SelectedDoctorId == id).ToList();
        }

        public Patient? GetByUserId(int userId)
        {
            return _dbContext.Patients.FirstOrDefault(p => p.UserId == userId);
        }

    }
}
