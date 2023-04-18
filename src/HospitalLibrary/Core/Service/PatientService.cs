using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public List<Patient> GetAll() => _patientRepository.GetAll();

        public List<Patient> GetBySelectedDoctorId(int id) => _patientRepository.GetBySelectedDoctorId(id).ToList();

        public Patient? GetById(int id) => _patientRepository.GetById(id);

        public Patient Create(Patient patient) => _patientRepository.Create(patient);

        public void Update(Patient patient) => _patientRepository.Update(patient);

        public void Delete(int id) => _patientRepository.Delete(id);

        public Patient GetByUserId(int userId) => _patientRepository.GetByUserId(userId);

        public Patient CreateAndAddAllergens(Patient patient, List<Allergen> allers)
        {
            patient.Allergens = allers;
            return _patientRepository.Create(patient);
        }


    }
}
