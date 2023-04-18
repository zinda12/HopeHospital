using HospitalLibrary.Core.Model.ValueObjects;

namespace HospitalLibrary.Core.DomainService
{
    public class DoctorScheduler
    {
        private const int BASE_SLOT_DURATION = 30;
        private readonly TimeOnly START_WORK_HOUR = new(7, 0);
        private readonly TimeOnly END_WORK_HOUR = new(20, 0);

        public List<DateRange> FindAvailableAppointments(
            DateRange dateRange,
            int slotDuration,
            List<DateRange> doctorsBusyAppointments)
        {
            var availableAppointments = new List<DateRange>();
            foreach (var day in dateRange.EachDay())
                availableAppointments.AddRange(FindAvailableAppointments(DateOnly.FromDateTime(day), slotDuration, doctorsBusyAppointments));
            return availableAppointments;
        }

        public List<DateRange> FindAvailableAppointments(
            DateOnly date,
            int slotDuration,
            List<DateRange> doctorAppointments)
        {
            var availableSlots = new List<DateRange>();
            TimeOnly time = START_WORK_HOUR;
            while (time < END_WORK_HOUR)
            {
                var dateTimeToCheck = date.ToDateTime(time);
                var appointmentToCheck = doctorAppointments.Find(a => a.Contains(dateTimeToCheck));
                if (appointmentToCheck is null)
                {
                    availableSlots.Add(new DateRange(dateTimeToCheck, dateTimeToCheck.AddMinutes(BASE_SLOT_DURATION)));
                    time = time.AddMinutes(BASE_SLOT_DURATION);
                }
                else
                    time = time.AddMinutes(appointmentToCheck.DurationInMinutes);
            }
            return slotDuration == BASE_SLOT_DURATION ? availableSlots : MergeSlots(availableSlots, slotDuration / BASE_SLOT_DURATION);
        }

        public bool IsAvailable(DateRange dateRange, List<DateRange> doctorsBusyAppointments)
        {
            foreach (var busyAppointment in doctorsBusyAppointments)
            {
                if (busyAppointment.IsOverlapped(dateRange))
                    return false;
            }
            return true;
        }

        private static List<DateRange> MergeSlots(List<DateRange> slots, int slotsToMerge)
        {
            int mergedSlotsCounter = 1;
            int mergingSlotIndex = 0;
            for (int i = 1; i < slots.Count; i++)
            {
                slots[mergingSlotIndex] = slots[mergingSlotIndex].ExtendEndByMinutes(BASE_SLOT_DURATION);
                if (slots[mergingSlotIndex].End == slots[i].End)
                {
                    if (++mergedSlotsCounter != slotsToMerge)
                        continue;
                    else
                        i = ++mergingSlotIndex;
                }
                else
                {
                    slots.Remove(slots[mergingSlotIndex]);
                    i = mergingSlotIndex;
                }
                mergedSlotsCounter = 1;
            }
            if (mergingSlotIndex > slots.Count - slotsToMerge)
                slots.RemoveRange(mergingSlotIndex, slotsToMerge - 1);
            return slots;
        }

    }
}
