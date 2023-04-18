using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings.DataSeed;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Allergen> Allergens { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedRooms();
            modelBuilder.SeedAddress();
            modelBuilder.SeedDoctor();
            modelBuilder.SeedPatient();
            modelBuilder.SeedFeedback();
            modelBuilder.SeedExamination();
            modelBuilder.SeedAllergen();

            base.OnModelCreating(modelBuilder);

        }

    }
}