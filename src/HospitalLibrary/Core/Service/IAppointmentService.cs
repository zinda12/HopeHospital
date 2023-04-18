using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.ValueObjects;

namespace HospitalLibrary.Core.Service
{
    public interface IAppointmentService
    {
        public AvailableAppointments GetAvailableAppointments(DateTime date, int doctorId);
        public AvailableAppointments GetAvailableAppointments(DateRange dateRange, int doctorId);
        public List<AvailableAppointments> GetRecommendedAvailableAppointments(DateRange dateRange, int doctorId, AppointmentPriority priority);
        
    }
}
