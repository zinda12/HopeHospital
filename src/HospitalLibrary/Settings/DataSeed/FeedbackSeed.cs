using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class FeedbackSeed
    {
        public static void SeedFeedback(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>(f =>
            {
                f.HasData(new Feedback(1, 1, "Bolnica je dobra", true, true, FeedbackStatus.OnHold));
                f.OwnsOne(e => e.Rating).HasData(new
                {
                    FeedbackId = 1,
                    Rating = 3
                });
                f.HasData(new Feedback(2, 2, "Bolnica je losa", false, true, FeedbackStatus.OnHold));
                f.OwnsOne(e => e.Rating).HasData(new
                {
                    FeedbackId = 2,
                    Rating = 4
                });
                f.HasData(new Feedback(3, 3, "Bolnica je odlicna", false, true, FeedbackStatus.Approved));
                f.OwnsOne(e => e.Rating).HasData(new
                {
                    FeedbackId = 3,
                    Rating = 5
                });
                f.HasData(new Feedback(4, 4, "Bolnica je solidna", true, true, FeedbackStatus.OnHold));
                f.OwnsOne(e => e.Rating).HasData(new
                {
                    FeedbackId = 4,
                    Rating = 5
                });
            });
        }

    }
}
