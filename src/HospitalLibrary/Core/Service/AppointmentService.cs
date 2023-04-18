using HospitalLibrary.Core.DomainService;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly DoctorScheduler _doctorScheduler;

        public AppointmentService(
            IAppointmentRepository appointmentRepository,
            IDoctorRepository doctorRepository,
            DoctorScheduler doctorScheduler)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
            _doctorScheduler = doctorScheduler;
        }

        public AvailableAppointments GetAvailableAppointments(DateTime date, int doctorId)
        {
            var doctor = _doctorRepository.GetById(doctorId);
            var doctorsBusyAppointments = _appointmentRepository.GetDoctorsBusyAppointments(doctorId, date);
            var doctorsAvailableAppointments = _doctorScheduler.FindAvailableAppointments(DateOnly.FromDateTime(date), 30, doctorsBusyAppointments);
            return new AvailableAppointments(doctor, doctorsAvailableAppointments);
        }

        public AvailableAppointments GetAvailableAppointments(DateRange dateRange, int doctorId)
        {
            var doctor = _doctorRepository.GetById(doctorId);
            var doctorsBusyAppointments = _appointmentRepository.GetDoctorsBusyAppointments(doctorId, dateRange);
            var doctorsAvailableAppointments = _doctorScheduler.FindAvailableAppointments(dateRange, 30, doctorsBusyAppointments);
            return new AvailableAppointments(doctor, doctorsAvailableAppointments);
        }

        public List<AvailableAppointments> GetRecommendedAvailableAppointments(DateRange dateRange, int doctorId, AppointmentPriority priority)
        {
            var availableAppointments = new List<AvailableAppointments>();
            var doctorsAvailableAppointments = GetAvailableAppointments(dateRange, doctorId);
            if (doctorsAvailableAppointments.Slots.Count != 0)
            {
                availableAppointments.Add(doctorsAvailableAppointments);
                return availableAppointments;
            }
            return ApplyAppointmentPriority(dateRange, doctorId, priority);
        }

        private List<AvailableAppointments> ApplyAppointmentPriority(DateRange dateRange, int doctorId, AppointmentPriority priority)
        {
            var availableAppointments = new List<AvailableAppointments>();
            var doctor = _doctorRepository.GetById(doctorId);
            if (priority == AppointmentPriority.DOCTOR)
            {
                dateRange = dateRange.ExtendByDays(5);
                var doctorsAvailableAppointments = GetAvailableAppointments(dateRange, doctorId);
                availableAppointments.Add(doctorsAvailableAppointments);
            }
            else
            {
                var doctors = _doctorRepository.GetBySpecialization(doctor.Specialization);
                foreach (var doc in doctors)
                {
                    var doctorsAvailableAppointments = GetAvailableAppointments(dateRange, doc.Id);
                    if (doctorsAvailableAppointments.Slots.Count != 0)
                        availableAppointments.Add(doctorsAvailableAppointments);
                }
            }
            return availableAppointments;
        }
    }
}
