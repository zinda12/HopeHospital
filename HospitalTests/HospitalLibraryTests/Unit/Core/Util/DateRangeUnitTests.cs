using HospitalLibrary.Core.Model.ValueObjects;
using Shouldly;

namespace HospitalTests.HospitalLibraryTests.Unit.Core.Util
{
    public class DateRangeUnitTests
    {
        [Fact]
        public void Create_ValidParameters()
        {
            // Arrange
            DateTime from = new(2022, 12, 1);
            DateTime to = new(2022, 12, 10);

            // Act
            var dateRange = new DateRange(from, to);

            // Assert
            dateRange.ShouldNotBeNull();
        }

        [Fact]
        public void Create_InvalidParameters() 
        {
            // Arrange
            DateTime from = new(2022, 12, 10);
            DateTime to = new(2022, 12, 1);

            // Assert
            Should.Throw<Exception>(() => new DateRange(from, to));
        }

        [Theory, MemberData(nameof(ContainsTestData))]
        public void Contains(DateTime dateTime, bool containsResult)
        {
            // Arrange
            var dateRange = new DateRange(
                new DateTime(2022, 12, 1),
                new DateTime(2022, 12, 10));

            // Act
            var result = dateRange.Contains(dateTime);

            // Assert
            if (containsResult)
                result.ShouldBeTrue();
            else
                result.ShouldBeFalse();
        }

        [Theory, MemberData(nameof(IsOverlappedTestData))]
        public void IsOverlapped(DateRange dateRange, DateRange dateRange1, bool overlapResult)
        {
            // Act
            var result = dateRange.IsOverlapped(dateRange1);

            // Assert
            if (overlapResult)
                result.ShouldBeTrue();
            else
                result.ShouldBeFalse();
        }

        [Fact]
        public void ExtendByDays_SuccessfulExtension()
        {
            // Arrange
            var dateRange = new DateRange(
                new DateTime(2022, 12, 1),
                new DateTime(2022, 12, 10));

            // Act
            var extendedDateRange = dateRange.ExtendByDays(5);

            // Assert
            Should.Equals(extendedDateRange.Start, dateRange.Start.AddDays(-5));
            Should.Equals(extendedDateRange.End, dateRange.End.AddDays(5));
        }

        [Fact]
        public void ExtendByDays_FailedExtension()
        {
            // Arrange
            var dateRange = new DateRange(
                new DateTime(2022, 12, 1),
                new DateTime(2022, 12, 10));

            // Assert
            Should.Throw<Exception>(() => dateRange.ExtendByDays(-10));
        }

        public static IEnumerable<object[]> IsOverlappedTestData() =>
            new List<object[]>()
            {
                new object[] { 
                    new DateRange(
                        new DateTime(2022, 12 ,1),
                        new DateTime(2022, 12, 10)),
                    new DateRange(
                        new DateTime(2022, 12 ,1),
                        new DateTime(2022, 12, 10)),
                    true
                },
                new object[] {
                    new DateRange(
                        new DateTime(2022, 12 ,1),
                        new DateTime(2022, 12, 10)),
                    new DateRange(
                        new DateTime(2022, 11 ,30),
                        new DateTime(2022, 12, 5)),
                    true
                },
                new object[] {
                    new DateRange(
                        new DateTime(2022, 12 ,1),
                        new DateTime(2022, 12, 10)),
                    new DateRange(
                        new DateTime(2022, 12 ,5),
                        new DateTime(2022, 12, 7)),
                    true
                },
                new object[] {
                    new DateRange(
                        new DateTime(2022, 12 ,1),
                        new DateTime(2022, 12, 10)),
                    new DateRange(
                        new DateTime(2022, 12 ,11),
                        new DateTime(2022, 12, 15)),
                    false
                }
            };

        public static IEnumerable<object[]> ContainsTestData() =>
            new List<object[]>()
            {
                new object[] { new DateTime(2022, 12 , 1), true },
                new object[] { new DateTime(2022, 12 , 5), true },
                new object[] { new DateTime(2022, 11 , 30), false },
                new object[] { new DateTime(2022, 12 , 11), false }
            };

    }
}
