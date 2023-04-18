using HospitalLibrary.Core.DomainService;
using HospitalLibrary.Core.Model.ValueObjects;
using Shouldly;

namespace HospitalTests.HospitalLibraryTests.Unit.Core.Util
{
    public class DoctorSchedulerUnitTests
    {

        [Theory]
        [InlineData(30)]
        [InlineData(60)]
        [InlineData(90)]
        [InlineData(120)]
        public void FindAvailableAppointments(int slotDuration)
        {
            // Arrange
            var doctorAppointments = GetDoctorAppointments();
            var date = new DateOnly(2022, 12, 1);
            var doctorScheduler = new DoctorScheduler();

            // Act
            var availableAppointments = doctorScheduler.FindAvailableAppointments(date, slotDuration, doctorAppointments);

            // Assert
            foreach (var availableAppointment in availableAppointments)
            {
                foreach (var doctorAppointment in doctorAppointments)
                    availableAppointment.IsOverlapped(doctorAppointment).ShouldBeFalse();
                availableAppointment.DurationInMinutes.ShouldBe(slotDuration);
            }
        }

        private static List<DateRange> GetDoctorAppointments()
        {
            return new List<DateRange>()
            {
                new DateRange(new DateTime(2022, 12, 1, 7, 0, 0), new DateTime(2022, 12, 1, 7, 30, 0)),
                new DateRange(new DateTime(2022, 12, 1, 8, 0, 0), new DateTime(2022, 12, 1, 8, 30, 0)),
                new DateRange(new DateTime(2022, 12, 1, 10, 0, 0), new DateTime(2022, 12, 1, 10, 30, 0)),
                new DateRange(new DateTime(2022, 12, 1, 10, 30, 0), new DateTime(2022, 12, 1, 11, 0, 0)),
                new DateRange(new DateTime(2022, 12, 1, 12, 0, 0), new DateTime(2022, 12, 1, 12, 30, 0)),
            };
        }
    }
}
