using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HospitalLibrary.Core.Model.ValueObjects
{
    [Owned]
    public class FeedbackRating : ValueObject
    {
        public int Rating { get; private set; }

        public FeedbackRating(int rating)
        {
            Rating = rating;
            Validate();
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Rating;
        }

        private void Validate()
        {
            if (Rating <= 0 && Rating > 5)
                throw new ArgumentException("Invalid arguments, rating must be beetween 1 and 5");
        }
    }
}
