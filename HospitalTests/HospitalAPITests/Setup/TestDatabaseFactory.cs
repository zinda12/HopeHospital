using HospitalAPI;
using HospitalAPI.Security;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalTests.HospitalAPITests.Setup
{
    public class TestDatabaseFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                using var scope = BuildServiceProvider(services).CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<HospitalDbContext>();
                var identityDb = scopedServices.GetRequiredService<AppIdentityDbContext>();

                InitializeDatabase(db);
                InitializeIdentityDatabase(identityDb);
            });
        }

        private static ServiceProvider BuildServiceProvider(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<HospitalDbContext>));
            services.Remove(descriptor);
            services.AddDbContext<HospitalDbContext>(opt =>
            {
                opt.UseNpgsql(CreateConnectionStringForTest());
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<AppIdentityDbContext>));
            services.Remove(descriptor);
            services.AddDbContext<AppIdentityDbContext>(opt => opt.UseNpgsql(CreateConnectionStringForTest()));

            return services.BuildServiceProvider();
        }

        private static string CreateConnectionStringForTest()
        {
            return "Host=localhost;Database=HospitalTestDb;Username=postgres;Password=password;";
        }

        private static void InitializeDatabase(HospitalDbContext context)
        {
            context.Database.EnsureCreated();
            context.SaveChanges();
        }

        private static void InitializeIdentityDatabase(AppIdentityDbContext context)
        {
            context.Database.EnsureCreated();
            context.SaveChanges();
        }
    }
}
