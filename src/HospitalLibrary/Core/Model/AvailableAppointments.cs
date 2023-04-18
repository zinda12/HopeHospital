using HospitalLibrary.Core.Model.ValueObjects;

namespace HospitalLibrary.Core.Model
{
    public class AvailableAppointments
    {
        public Doctor Doctor { get; }
        public List<DateRange> Slots { get; }

        public AvailableAppointments(Doctor doctor, List<DateRange> slots)
        {
            Doctor = doctor;
            Slots = slots;
        }

    }
}
