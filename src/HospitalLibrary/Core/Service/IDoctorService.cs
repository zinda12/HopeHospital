using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;


namespace HospitalLibrary.Core.Service
{
    public interface IDoctorService
    {
        IEnumerable<Doctor> GetAll();
        IEnumerable<Doctor> GetAllGeneralPracticioners();
        Doctor GetById(int id);
        void Create(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(Doctor doctor);
        public List<Doctor> GetBySpecialization(DoctorSpecialization specialization);
    }
}