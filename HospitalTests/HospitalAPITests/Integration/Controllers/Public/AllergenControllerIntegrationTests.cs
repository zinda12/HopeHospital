using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers.PublicApp;
using HospitalLibrary.Core.Service;
using HospitalTests.HospitalAPITests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;


namespace HospitalTests.HospitalAPITests.Integration.Controllers.Public
{
    public class AllergenControllerIntegrationTests : BaseIntegrationTest
    {
        public AllergenControllerIntegrationTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static AllergenController SetupController(IServiceScope scope)
        {
            return new AllergenController(scope.ServiceProvider.GetRequiredService<IAllergenService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        [Fact]
        public void Get_all_allergens()
        {
            // Arange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            

            // Act
            var result = controller.GetAll();

            // Assert
            result.ShouldBeOfType(typeof(OkObjectResult));
        }
    }
}
