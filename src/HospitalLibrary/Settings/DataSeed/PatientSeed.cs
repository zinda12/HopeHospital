using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class PatientSeed
    {
        public static void SeedPatient(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Patient>(p =>
            {
                p.HasData(new Patient(1, "Pera", "Peric", "peraperic@gmail.com", Core.Enums.Gender.MALE, Core.Enums.BloodType.ZERO_POSITIVE, 1, 1, 5));
                p.OwnsOne(e => e.Pin).HasData(new
                {
                    PatientId = 1,
                    Value = "2201000120492"
                });

                p.HasData(new Patient(2, "Marko", "Markovic", "markomarkovic@gmail.com", Core.Enums.Gender.MALE, Core.Enums.BloodType.AB_NEGATIVE, 2, 2, 6));
                p.OwnsOne(e => e.Pin).HasData(new
                {
                    PatientId = 2,
                    Value = "1412995012451"
                });

                p.HasData(new Patient(3, "Dusan", "Baljinac", "dusanbaljinac@gmail.com", Core.Enums.Gender.MALE, Core.Enums.BloodType.B_NEGATIVE, 3, 1, 7));
                p.OwnsOne(e => e.Pin).HasData(new
                {
                    PatientId = 3,
                    Value = "2008004124293"
                });

                p.HasData(new Patient(4, "Slobodan", "Radulovic", "slobodanradulovic@gmail.com", Core.Enums.Gender.MALE, Core.Enums.BloodType.A_NEGATIVE, 4, 2, 8));
                p.OwnsOne(e => e.Pin).HasData(new
                {
                    PatientId = 4,
                    Value = "1111952020204"
                });
            });

        }
    }
}
