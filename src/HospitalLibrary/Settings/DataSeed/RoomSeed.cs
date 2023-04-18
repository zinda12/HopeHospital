
using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class RoomSeed
    {
        public static void SeedRooms(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData(
                new Room(1, "Soba 12"),
                new Room(2, "Soba 13 "),
                new Room(3, "Soba 14"));

        }
    }
}
