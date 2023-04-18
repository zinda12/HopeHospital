using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.ValueObjects;

namespace HospitalLibrary.Core.Repository
{
    public interface IExaminationRepository
    {
        IEnumerable<Examination> GetAll();
        Examination? GetById(int id);
        void Create(Examination examination);
        void Update(Examination examination);
        void Delete(Examination examination);
        IEnumerable<Examination> GetByDate(DateTime startTime);
        IEnumerable<Examination> GetByDoctorAndDate(int doctorId, DateTime date);
        public List<DateRange> GetByDoctorAndDateRange(int doctorId, DateRange dateRange);
        IEnumerable<Examination> GetByPatientId(int patientId);
        IEnumerable<Examination> GetByRoomId(int roomId);
    }
}