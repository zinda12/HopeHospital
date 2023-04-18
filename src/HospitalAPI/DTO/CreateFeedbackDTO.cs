using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.DTO
{
    public class CreateFeedbackDTO
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        [Required]
        public bool IsAnonymous { get; set; }
        public FeedbackRating Rating { get; set; }
    }
}
