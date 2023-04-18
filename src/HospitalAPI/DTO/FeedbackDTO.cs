using HospitalLibrary.Core.Model;

namespace HospitalAPI.DTO
{
    public class FeedbackDTO
    {
        public int Id { get; set; }
        public string PatientFullName { get; set; }
        public string Text { get; set; }
        public DateOnly CreationDate { get; set; }
        public bool IsPublic { get; set; }
        public FeedbackStatus Status { get; set; }
    }

}
