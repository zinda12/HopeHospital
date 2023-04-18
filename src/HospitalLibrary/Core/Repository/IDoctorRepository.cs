using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface IDoctorRepository
    {
        public List<Doctor> GetAll();
        public Doctor GetById(int id);
        public List<Doctor> GetBySpecialization(DoctorSpecialization specialization);
        public void Create(Doctor doctor);
        public void Update(Doctor doctor);
        public void Delete(Doctor doctor);
        public IEnumerable<Doctor> GetAllGeneralPracticioners();
    }

}