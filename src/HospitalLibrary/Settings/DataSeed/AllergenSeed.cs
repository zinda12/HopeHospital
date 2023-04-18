using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class AllergenSeed
    {
        public static void SeedAllergen(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allergen>().HasData(
                new Allergen(1, "Penicilin"),
                new Allergen(2, "Sulfonamidi "),
                new Allergen(3, "Salicilna kiselina"));

        }
    }
}
