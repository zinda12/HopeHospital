using HospitalAPI.Security.Models;
using Microsoft.AspNetCore.Identity;

namespace HospitalAPI.Security
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService <RoleManager<IdentityRole<int>>>();
            
            await roleManager.CreateAsync(new IdentityRole<int>("Patient"));
            await roleManager.CreateAsync(new IdentityRole<int>("Doctor"));
            await roleManager.CreateAsync(new IdentityRole<int>("Manager"));
            await roleManager.CreateAsync(new IdentityRole<int>("BloodBank"));
            
            var patientUser = new User()
            {
                UserName = "patient",
                Email= "patient@email.com"
            };
            await userManager.CreateAsync(patientUser, "12345");
            await userManager.AddToRoleAsync(patientUser, "Patient");
            await userManager.SetLockoutEnabledAsync(patientUser, false);

            var doctorUser = new User()
            {
                UserName = "doctor",
                Email = "doctor@email.com"
            };
            await userManager.CreateAsync(doctorUser, "12345");
            await userManager.AddToRoleAsync(doctorUser, "Doctor");
            await userManager.SetLockoutEnabledAsync(doctorUser, false);

            var managerUser = new User()
            {
                UserName = "manager",
                Email = "manager@email.com"
            };
            await userManager.CreateAsync(managerUser, "12345");
            await userManager.AddToRoleAsync(managerUser, "Manager");
            await userManager.SetLockoutEnabledAsync(managerUser, false);

            var bloodBankUser = new User()
            {
                UserName = "bloodBank",
                Email = "bloodbank@email.com"
            };
            await userManager.CreateAsync(bloodBankUser, "12345");
            await userManager.AddToRoleAsync(bloodBankUser, "BloodBank");
            await userManager.SetLockoutEnabledAsync(bloodBankUser, false);

            var patient1 = new User()
            {
                UserName = "peraperic",
                Email = "peraperic@email.com"
            };
            await userManager.CreateAsync(patient1, "12345");
            await userManager.AddToRoleAsync(patient1, "Patient");
            await userManager.SetLockoutEnabledAsync(patient1, false);

            var patient2 = new User()
            {
                UserName = "markomarkovic",
                Email = "markomarkovic@email.com"
            };
            await userManager.CreateAsync(patient2, "12345");
            await userManager.AddToRoleAsync(patient2, "Patient");
            await userManager.SetLockoutEnabledAsync(patient2, false);

            var patient3 = new User()
            {
                UserName = "dusanbaljinac",
                Email = "dusanbaljinac@email.com"
            };
            await userManager.CreateAsync(patient3, "12345");
            await userManager.AddToRoleAsync(patient3, "Patient");
            await userManager.SetLockoutEnabledAsync(patient3, false);

            var patient4 = new User()
            {
                UserName = "slobodanradulovic",
                Email = "slobodanradulovic@email.com"
            };
            await userManager.CreateAsync(patient4, "12345");
            await userManager.AddToRoleAsync(patient4, "Patient");
            await userManager.SetLockoutEnabledAsync(patient4, false);
        }
    }
}
