using HospitalLibrary.Core.Model.ValueObjects;

namespace HospitalAPI.DTO
{
    public class AvailableAppointmentsDTO
    {
        public DoctorDTO Doctor { get; set; }
        public List<DateRange> Slots{ get; set; }
    }
}
