using AngleSharp.Css;
using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers.PublicApp;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Service;
using HospitalTests.HospitalAPITests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace HospitalTests.HospitalAPITests.Integration.Controllers.Public
{
    public class AppointmentControllerIntegrationTests : BaseIntegrationTest
    {
        public AppointmentControllerIntegrationTests(TestDatabaseFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]
        [MemberData(nameof(GetRecommendedExaminationTimeTestData))]
        public void GetRecommendedExaminationTime_ReturnsDataRangeList(
            DateTime from,
            DateTime to,
            int doctorId,
            AppointmentPriority priority)
        {
            // Arange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            // Act
            var result = controller.GetRecommendedExaminationTime(from, to, doctorId, priority);

            // Assert
            result.Result.ShouldBeOfType(typeof(OkObjectResult));
            ((OkObjectResult)result.Result).Value.ShouldBeOfType(typeof(List<AvailableAppointmentsDTO>));
        }

        [Theory, MemberData(nameof(GetAvailableExaminationTestData))]
        public void Get_available_examinations_by_doctor_and_date(DateTime date, int doctorId)
        {
            // Arange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            // Act
            var result = controller.GetAvailableAppointmentsByDateDoctor(date, doctorId);

            // Assert
            result.Result.ShouldBeOfType(typeof(OkObjectResult));
            ((OkObjectResult)result.Result).Value.ShouldBeOfType(typeof(AvailableAppointmentsDTO));

        }

        private AppointmentController SetupController(IServiceScope scope)
        {
            var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
            var appointmentService = scope.ServiceProvider.GetRequiredService<IAppointmentService>();
            return new AppointmentController(mapper, appointmentService);
        }

        public static IEnumerable<object[]> GetRecommendedExaminationTimeTestData() =>
            new List<object[]>()
            {
                new object[] { new DateTime(2022, 12, 1), new DateTime(2022, 12, 10), 1, AppointmentPriority.DOCTOR },
                new object[] { new DateTime(2022, 1, 1), new DateTime(2022, 1, 5), 1, AppointmentPriority.DATE }
            };
        public static IEnumerable<object[]> GetAvailableExaminationTestData() =>
            new List<object[]>()
            {
                new object[] { new DateTime(2022, 12, 1), 1 },
                new object[] { new DateTime(2022, 12, 1), 2 },
            };

    }
}
