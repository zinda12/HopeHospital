using HospitalLibrary.Core.DomainService;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Service
{
    public class ExaminationService : IExaminationService
    {
        private readonly IExaminationRepository _examinationRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly DoctorScheduler _doctorScheduler;

        public ExaminationService(
            IExaminationRepository examinationRepository,
            DoctorScheduler doctorScheduler,
            IAppointmentRepository appointmentRepository)
        {
            _examinationRepository = examinationRepository;
            _doctorScheduler = doctorScheduler;
            _appointmentRepository = appointmentRepository;
        }

        public IEnumerable<Examination> GetAll() => _examinationRepository.GetAll();

        public Examination? GetById(int id) => _examinationRepository.GetById(id);

        public IEnumerable<Examination> GetByRoomId(int roomId) => _examinationRepository.GetByRoomId(roomId);

        public void Delete(Examination examination) => _examinationRepository.Delete(examination);

        public IEnumerable<Examination> GetByDate(DateTime startTime) => _examinationRepository.GetByDate(startTime);

        public IEnumerable<Examination> GetByDoctorIdAndDate(int doctorId, DateTime startTime) => _examinationRepository.GetByDoctorAndDate(doctorId, startTime);

        public IEnumerable<Examination> GetByPatientId(int patientId) => _examinationRepository.GetByPatientId(patientId);

        public bool Create(Examination examination)
        {
            if (!IsAvailable(examination))
                return false;
            _examinationRepository.Create(examination);
            return true;
        }

        public bool Update(Examination examination)
        {
            var examinationToUpdate = _examinationRepository.GetById(examination.Id);
            if (examinationToUpdate.DateRange != examination.DateRange && !IsAvailable(examination, examinationToUpdate.DateRange))
                return false;
            examination.RoomId = examinationToUpdate.RoomId;
            _examinationRepository.Update(examination);
            return true;
        }

        private bool IsAvailable(Examination examination, DateRange dateRangeToIgnore=null)
        {
            var doctorsBusyAppointments = _appointmentRepository.GetDoctorsBusyAppointments(examination.DoctorId, examination.DateRange.Start.Date);
            if (dateRangeToIgnore is not null)
                doctorsBusyAppointments = doctorsBusyAppointments.Where(dr => dateRangeToIgnore != dr).ToList();
            return _doctorScheduler.IsAvailable(examination.DateRange, doctorsBusyAppointments);
        }

        public bool CheckIfCancellable(int id)
        {
            var examination = _examinationRepository.GetById(id);
            if(examination.DateRange.Start < DateTime.Now || (examination.DateRange.Start - DateTime.Now) <= TimeSpan.FromHours(24) || examination == null)
            {
                return false;
            } else
            {
                examination.Status = ExaminationStatus.CANCELED;
                _examinationRepository.Update(examination);
                return true;
            }
        }
    }
}