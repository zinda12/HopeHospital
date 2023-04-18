using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
using HospitalLibrary.Core.Enums;

namespace HospitalLibrary.Settings.DataSeed
{
    public static class ExaminationSeed
    {
        public static void SeedExamination(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Examination>(b =>
            {
                b.HasData(new Examination(1, 1, 1, 1, ExaminationStatus.FINISHED));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 1,
                    Start = new DateTime(2022, 12, 1, 7, 0, 0),
                    End = new DateTime(2022, 12, 1, 7, 30, 0)
                });

                b.HasData(new Examination(2, 1, 1, 2, ExaminationStatus.FINISHED));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 2,
                    Start = new DateTime(2022, 12, 1, 8, 0, 0),
                    End = new DateTime(2022, 12, 1, 8, 30, 0)
                });

                b.HasData(new Examination(3, 2, 1, 2, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 3,
                    Start = new DateTime(2022, 12, 15, 12, 0, 0),
                    End = new DateTime(2022, 12, 15, 12, 30, 0)
                });

                b.HasData(new Examination(4, 3, 1, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 4,
                    Start = new DateTime(2023, 1, 22, 8, 0, 0),
                    End = new DateTime(2023, 1, 22, 8, 30, 0)
                });

                b.HasData(new Examination(5, 1, 1, 1, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 5,
                    Start = new DateTime(2023, 2, 5, 9, 0, 0),
                    End = new DateTime(2023, 2, 5, 9, 30, 0)
                });

                b.HasData(new Examination(6, 1, 1, 1, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 6,
                    Start = new DateTime(2022, 12, 27, 7, 0, 0),
                    End = new DateTime(2022, 12, 27, 7, 30, 0)
                });

                b.HasData(new Examination(7, 1, 3, 3, ExaminationStatus.FINISHED));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 7,
                    Start = new DateTime(2022, 12, 1, 8, 30, 0),
                    End = new DateTime(2022, 12, 1, 9, 0, 0)
                });

                b.HasData(new Examination(8, 1, 3, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 8,
                    Start = new DateTime(2023, 1, 23, 7, 0, 0),
                    End = new DateTime(2023, 1, 23, 7, 30, 0)
                });

                b.HasData(new Examination(9, 1, 1, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 9,
                    Start = new DateTime(2023, 1, 23, 7, 30, 0),
                    End = new DateTime(2023, 1, 23, 8, 0, 0)
                });

                b.HasData(new Examination(10, 1, 2, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 10,
                    Start = new DateTime(2023, 1, 23, 8, 0, 0),
                    End = new DateTime(2023, 1, 23, 8, 30, 0)
                });

                b.HasData(new Examination(11, 1, 3, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 11,
                    Start = new DateTime(2023, 1, 23, 8, 30, 0),
                    End = new DateTime(2023, 1, 23, 9, 0, 0)
                });

                b.HasData(new Examination(12, 1, 4, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 12,
                    Start = new DateTime(2023, 1, 23, 9, 0, 0),
                    End = new DateTime(2023, 1, 23, 9, 30, 0)
                });

                b.HasData(new Examination(13, 1, 1, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 13,
                    Start = new DateTime(2023, 1, 23, 9, 30, 0),
                    End = new DateTime(2023, 1, 23, 10, 0, 0)
                });

                b.HasData(new Examination(14, 1, 2, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 14,
                    Start = new DateTime(2023, 1, 23, 10, 0, 0),
                    End = new DateTime(2023, 1, 23, 10, 30, 0)
                });

                b.HasData(new Examination(15, 1, 3, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 15,
                    Start = new DateTime(2023, 1, 23, 10, 30, 0),
                    End = new DateTime(2023, 1, 23, 11, 0, 0)
                });

                b.HasData(new Examination(16, 1, 4, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 16,
                    Start = new DateTime(2023, 1, 23, 11, 0, 0),
                    End = new DateTime(2023, 1, 23, 11, 30, 0)
                });

                b.HasData(new Examination(17, 1, 1, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 17,
                    Start = new DateTime(2023, 1, 23, 11, 30, 0),
                    End = new DateTime(2023, 1, 23, 12, 0, 0)
                });

                b.HasData(new Examination(18, 1, 2, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 18,
                    Start = new DateTime(2023, 1, 23, 12, 0, 0),
                    End = new DateTime(2023, 1, 23, 12, 30, 0)
                });

                b.HasData(new Examination(19, 1, 3, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 19,
                    Start = new DateTime(2023, 1, 23, 12, 30, 0),
                    End = new DateTime(2023, 1, 23, 13, 0, 0)
                });

                b.HasData(new Examination(20, 1, 4, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 20,
                    Start = new DateTime(2023, 1, 23, 13, 0, 0),
                    End = new DateTime(2023, 1, 23, 13, 30, 0)
                });

                b.HasData(new Examination(21, 1, 1, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 21,
                    Start = new DateTime(2023, 1, 23, 13, 30, 0),
                    End = new DateTime(2023, 1, 23, 14, 0, 0)
                });

                b.HasData(new Examination(22, 1, 2, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 22,
                    Start = new DateTime(2023, 1, 23, 14, 0, 0),
                    End = new DateTime(2023, 1, 23, 14, 30, 0)
                });

                b.HasData(new Examination(23, 1, 3, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 23,
                    Start = new DateTime(2023, 1, 23, 14, 30, 0),
                    End = new DateTime(2023, 1, 23, 15, 0, 0)
                });

                b.HasData(new Examination(24, 1, 4, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 24,
                    Start = new DateTime(2023, 1, 23, 15, 0, 0),
                    End = new DateTime(2023, 1, 23, 15, 30, 0)
                });

                b.HasData(new Examination(25, 1, 1, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 25,
                    Start = new DateTime(2023, 1, 23, 15, 30, 0),
                    End = new DateTime(2023, 1, 23, 16, 0, 0)
                });

                b.HasData(new Examination(26, 1, 2, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 26,
                    Start = new DateTime(2023, 1, 23, 16, 0, 0),
                    End = new DateTime(2023, 1, 23, 16, 30, 0)
                });

                b.HasData(new Examination(27, 1, 3, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 27,
                    Start = new DateTime(2023, 1, 23, 16, 30, 0),
                    End = new DateTime(2023, 1, 23, 17, 0, 0)
                });

                b.HasData(new Examination(28, 1, 4, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 28,
                    Start = new DateTime(2023, 1, 23, 17, 0, 0),
                    End = new DateTime(2023, 1, 23, 17, 30, 0)
                });

                b.HasData(new Examination(29, 1, 1, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 29,
                    Start = new DateTime(2023, 1, 23, 17, 30, 0),
                    End = new DateTime(2023, 1, 23, 18, 0, 0)
                });

                b.HasData(new Examination(30, 1, 2, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 30,
                    Start = new DateTime(2023, 1, 23, 18, 0, 0),
                    End = new DateTime(2023, 1, 23, 18, 30, 0)
                });

                b.HasData(new Examination(31, 1, 3, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 31,
                    Start = new DateTime(2023, 1, 23, 18, 30, 0),
                    End = new DateTime(2023, 1, 23, 19, 0, 0)
                });

                b.HasData(new Examination(32, 1, 4, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 32,
                    Start = new DateTime(2023, 1, 23, 19, 0, 0),
                    End = new DateTime(2023, 1, 23, 19, 30, 0)
                });

                b.HasData(new Examination(33, 1, 1, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 33,
                    Start = new DateTime(2023, 1, 23, 19, 30, 0),
                    End = new DateTime(2023, 1, 23, 20, 0, 0)
                });

                b.HasData(new Examination(34, 1, 3, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 34,
                    Start = new DateTime(2023, 1, 24, 7, 0, 0),
                    End = new DateTime(2023, 1, 24, 7, 30, 0)
                });

                b.HasData(new Examination(35, 1, 1, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 35,
                    Start = new DateTime(2023, 1, 24, 7, 30, 0),
                    End = new DateTime(2023, 1, 24, 8, 0, 0)
                });

                b.HasData(new Examination(36, 1, 2, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 36,
                    Start = new DateTime(2023, 1, 24, 8, 0, 0),
                    End = new DateTime(2023, 1, 24, 8, 30, 0)
                });

                b.HasData(new Examination(37, 1, 3, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 37,
                    Start = new DateTime(2023, 1, 24, 8, 30, 0),
                    End = new DateTime(2023, 1, 24, 9, 0, 0)
                });

                b.HasData(new Examination(38, 1, 4, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 38,
                    Start = new DateTime(2023, 1, 24, 9, 0, 0),
                    End = new DateTime(2023, 1, 24, 9, 30, 0)
                });

                b.HasData(new Examination(39, 1, 1, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 39,
                    Start = new DateTime(2023, 1, 24, 9, 30, 0),
                    End = new DateTime(2023, 1, 24, 10, 0, 0)
                });

                b.HasData(new Examination(40, 1, 2, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 40,
                    Start = new DateTime(2023, 1, 24, 10, 0, 0),
                    End = new DateTime(2023, 1, 24, 10, 30, 0)
                });

                b.HasData(new Examination(41, 1, 3, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 41,
                    Start = new DateTime(2023, 1, 24, 10, 30, 0),
                    End = new DateTime(2023, 1, 24, 11, 0, 0)
                });

                b.HasData(new Examination(42, 1, 4, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 42,
                    Start = new DateTime(2023, 1, 24, 11, 0, 0),
                    End = new DateTime(2023, 1, 24, 11, 30, 0)
                });

                b.HasData(new Examination(43, 1, 1, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 43,
                    Start = new DateTime(2023, 1, 24, 11, 30, 0),
                    End = new DateTime(2023, 1, 24, 12, 0, 0)
                });

                b.HasData(new Examination(44, 1, 2, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 44,
                    Start = new DateTime(2023, 1, 24, 12, 0, 0),
                    End = new DateTime(2023, 1, 24, 12, 30, 0)
                });

                b.HasData(new Examination(45, 1, 3, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 45,
                    Start = new DateTime(2023, 1, 24, 12, 30, 0),
                    End = new DateTime(2023, 1, 24, 13, 0, 0)
                });

                b.HasData(new Examination(46, 1, 4, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 46,
                    Start = new DateTime(2023, 1, 24, 13, 0, 0),
                    End = new DateTime(2023, 1, 24, 13, 30, 0)
                });

                b.HasData(new Examination(47, 1, 1, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 47,
                    Start = new DateTime(2023, 1, 24, 13, 30, 0),
                    End = new DateTime(2023, 1, 24, 14, 0, 0)
                });

                b.HasData(new Examination(48, 1, 2, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 48,
                    Start = new DateTime(2023, 1, 24, 14, 0, 0),
                    End = new DateTime(2023, 1, 24, 14, 30, 0)
                });

                b.HasData(new Examination(49, 1, 3, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 49,
                    Start = new DateTime(2023, 1, 24, 14, 30, 0),
                    End = new DateTime(2023, 1, 24, 15, 0, 0)
                });

                b.HasData(new Examination(50, 1, 4, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 50,
                    Start = new DateTime(2023, 1, 24, 15, 0, 0),
                    End = new DateTime(2023, 1, 24, 15, 30, 0)
                });

                b.HasData(new Examination(51, 1, 1, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 51,
                    Start = new DateTime(2023, 1, 24, 15, 30, 0),
                    End = new DateTime(2023, 1, 24, 16, 0, 0)
                });

                b.HasData(new Examination(52, 1, 2, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 52,
                    Start = new DateTime(2023, 1, 24, 16, 0, 0),
                    End = new DateTime(2023, 1, 24, 16, 30, 0)
                });

                b.HasData(new Examination(53, 1, 3, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 53,
                    Start = new DateTime(2023, 1, 24, 16, 30, 0),
                    End = new DateTime(2023, 1, 24, 17, 0, 0)
                });

                b.HasData(new Examination(54, 1, 4, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 54,
                    Start = new DateTime(2023, 1, 24, 17, 0, 0),
                    End = new DateTime(2023, 1, 24, 17, 30, 0)
                });

                b.HasData(new Examination(55, 1, 1, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 55,
                    Start = new DateTime(2023, 1, 24, 17, 30, 0),
                    End = new DateTime(2023, 1, 24, 18, 0, 0)
                });

                b.HasData(new Examination(56, 1, 2, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 56,
                    Start = new DateTime(2023, 1, 24, 18, 0, 0),
                    End = new DateTime(2023, 1, 24, 18, 30, 0)
                });

                b.HasData(new Examination(57, 1, 3, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 57,
                    Start = new DateTime(2023, 1, 24, 18, 30, 0),
                    End = new DateTime(2023, 1, 24, 19, 0, 0)
                });

                b.HasData(new Examination(58, 1, 4, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 58,
                    Start = new DateTime(2023, 1, 24, 19, 0, 0),
                    End = new DateTime(2023, 1, 24, 19, 30, 0)
                });

                b.HasData(new Examination(59, 1, 1, 3, ExaminationStatus.UPCOMING));
                b.OwnsOne(e => e.DateRange).HasData(new
                {
                    ExaminationId = 59,
                    Start = new DateTime(2023, 1, 24, 19, 30, 0),
                    End = new DateTime(2023, 1, 24, 20, 0, 0)
                });

            });
        }
    }
}