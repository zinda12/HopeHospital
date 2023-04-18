using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<Doctor> GetAll() => _doctorRepository.GetAll();
    
        public IEnumerable<Doctor> GetAllGeneralPracticioners() => _doctorRepository.GetAllGeneralPracticioners();
      
        public List<Doctor> GetBySpecialization(DoctorSpecialization specialization) => _doctorRepository.GetBySpecialization(specialization);
      
        public Doctor GetById(int id) => _doctorRepository.GetById(id);
    
        public void Create(Doctor doctor) => _doctorRepository.Create(doctor);

        public void Update(Doctor doctor) => _doctorRepository.Update(doctor);
  
        public void Delete(Doctor doctor) => _doctorRepository.Delete(doctor);
       
    }
}