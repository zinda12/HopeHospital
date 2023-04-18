using HospitalAPI.Security.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Security
{
    public class AppIdentityDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {

        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

    }
}
