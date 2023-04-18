using HospitalAPI;
using HospitalAPI.Controllers.Auth;
using HospitalAPI.Security;
using HospitalAPI.Security.Models;
using HospitalTests.HospitalAPITests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace HospitalTests.HospitalAPITests.Integration.Controllers.Auth
{
    public class AuthControllerIntegrationTests : BaseIntegrationTest
    {
        public AuthControllerIntegrationTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static AuthController SetupController(IServiceScope scope) 
        {
            return new AuthController(scope.ServiceProvider.GetRequiredService<AuthService>());
        }

        [Theory]
        [InlineData("test", "12345", typeof(OkObjectResult))]
        [InlineData("test", "123", typeof(BadRequestResult))]
        public async Task Login(string username, string password, Type resultType)
        {
            // Arange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            var loginRequest = new LoginRequest()
            {
                Username = username,
                Password = password,
            };

            // Act
            var result = await controller.LoginIntern(loginRequest);

            // Assert
            result.ShouldBeOfType(resultType);
        }

        [Theory]
        [InlineData("test11@gmail.com", "test11","12345", typeof(OkResult))]
        [InlineData("markovica@gmail.com", "test1","12345", typeof(BadRequestResult))]
        [InlineData("test1@gmail.com", "aleksa","12345", typeof(BadRequestResult))]
        public async Task Register(string email, string username,string password, Type resultType)
        {
            // Arange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
     
            var registerRequest = new RegisterRequest()
            {
                RegisterUser = null,
                Email = email,
                Username = username,
                Password = password,
            };

            // Act
            var result = await controller.Register(registerRequest);

            // Assert
            result.ShouldBeOfType(resultType);
        }

    }
}
