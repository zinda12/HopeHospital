using HospitalAPI.Controllers.PublicApp;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Service;
using HospitalTests.HospitalAPITests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using HospitalAPI;
using Shouldly;


namespace HospitalTests.HospitalAPITests.Integration.Controllers.Public
{
    public class ExaminationControllerIntegrationTests : BaseIntegrationTest
    {
        public ExaminationControllerIntegrationTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static ExaminationController SetupController(IServiceScope scope)
        {
            return new ExaminationController(scope.ServiceProvider.GetRequiredService<IMapper>(), scope.ServiceProvider.GetRequiredService<IExaminationService>(), scope.ServiceProvider.GetRequiredService<IDoctorService>(), scope.ServiceProvider.GetRequiredService<IPatientService>(), scope.ServiceProvider.GetRequiredService<IAppointmentService>());
        }

        [Fact]
        public void Retrieves_examinations()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = controller.GetExaminationsForPatient();

            result.ShouldNotBeNull();
            result.ShouldBeOfType(typeof(OkObjectResult));
            ((OkObjectResult)result).Value.ShouldBeOfType(typeof(List<ViewExaminationDTO>));
        }

        [Fact]
        public void Cancels_examination()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = controller.CancelExamination(6);

            result.ShouldNotBeNull();
            result.ShouldBeOfType(typeof(OkObjectResult));
            ((OkObjectResult)result).Value.ShouldBeOfType(typeof(bool));
            ((OkObjectResult)result).Value.ShouldBe(true);
        }

        [Fact]
        public void Fails_to_cancel_appointment()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = controller.CancelExamination(1);

            result.ShouldNotBeNull();
            result.ShouldBeOfType(typeof(OkObjectResult));
            ((OkObjectResult)result).Value.ShouldBeOfType(typeof(bool));
            ((OkObjectResult)result).Value.ShouldBe(false);
        }
    }
}