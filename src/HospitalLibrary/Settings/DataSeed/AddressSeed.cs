using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class AddressSeed
    {
        public static void SeedAddress(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
                new Address(1, "Srbija", "Novi Sad", "Dunavska 29", "12"),
                new Address(2, "Srbija", "Beograd", "Beogradska", "10"),
                new Address(3, "Srbija", "Sremska Mitrovica", "Skolska", "15"),
                new Address(4, "Srbija", "Gradska", "Njegoseva", "25"));
        }
    }
}
