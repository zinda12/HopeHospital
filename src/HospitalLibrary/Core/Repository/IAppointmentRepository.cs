using HospitalLibrary.Core.Model.ValueObjects;

namespace HospitalLibrary.Core.Repository
{
    public interface IAppointmentRepository
    {
        public List<DateRange> GetDoctorsBusyAppointments(int doctorId, DateTime date);
        public List<DateRange> GetDoctorsBusyAppointments(int doctorId, DateRange dateRange);
    }
}
