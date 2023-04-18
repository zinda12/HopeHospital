using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class DoctorSeed
    {
        public static void SeedDoctor(this ModelBuilder modelBuilder)
        {
            var workHour = new DateRange(new DateTime(2022, 12, 1, 8, 0, 0), new DateTime(2022, 12, 1, 16, 0, 0));

            modelBuilder.Entity<Doctor>(b =>
            {
                b.HasData(new Doctor(1, "Slobodan", "Radulovic", DoctorSpecialization.GENERAL_PRACTICIONER, 1));
                b.OwnsOne(d => d.WorkHour).HasData(new { 
                    DoctorId = 1,
                    Start = new DateTime(2022, 12, 1, 8, 0, 0),
                    End = new DateTime(2022, 12, 1, 16, 0, 0)
                });
                b.HasData(new Doctor(2, "Aleksa", "Zindovic", DoctorSpecialization.GENERAL_PRACTICIONER, 2));
                b.OwnsOne(d => d.WorkHour).HasData(new
                {
                    DoctorId = 2,
                    Start = new DateTime(2022, 12, 1, 8, 0, 0),
                    End = new DateTime(2022, 12, 1, 16, 0, 0)
                });
                b.HasData(new Doctor(3, "Mica", "Micic", DoctorSpecialization.GENERAL_PRACTICIONER, 3));
                b.OwnsOne(d => d.WorkHour).HasData(new
                {
                    DoctorId = 3,
                    Start = new DateTime(2022, 12, 1, 8, 0, 0),
                    End = new DateTime(2022, 12, 1, 16, 0, 0)
                });
            });
        }
    }
}
