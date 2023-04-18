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
    public class DoctorControllerIntegrationTests : BaseIntegrationTest
    {
        public DoctorControllerIntegrationTests(TestDatabaseFactory<Startup> factory) : base(factory)
        {

        }
        [Theory]
        [InlineData(DoctorSpecialization.GENERAL_PRACTICIONER)]
        public void Get_doctors_by_specialization(DoctorSpecialization specialization)
        {
            // Arange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            // Act
            var result = controller.GetDoctorsBySpecialization(specialization);

            // Assert
            result.Result.ShouldBeOfType(typeof(OkObjectResult));
            ((OkObjectResult)result.Result).Value.ShouldBeOfType(typeof(List<DoctorDTO>));
        }
        private DoctorController SetupController(IServiceScope scope)
        {
            var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
            var patientService = scope.ServiceProvider.GetRequiredService<IPatientService>();
            var doctorService = scope.ServiceProvider.GetRequiredService<IDoctorService>();
            return new DoctorController(doctorService, patientService, mapper);
        }
    }
}
