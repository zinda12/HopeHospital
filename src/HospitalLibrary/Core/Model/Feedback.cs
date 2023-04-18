using HospitalLibrary.Core.Model.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.Core.Model
{
    public class Feedback : BaseEntityModel
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public string Text { get; set; }
        public DateOnly CreationDate { get; set; }
        public bool IsAnonymous { get; set; }
        public bool IsPublic { get; set; }
        public FeedbackRating Rating { get; set; }
        public FeedbackStatus Status { get; set; }

        public Feedback()
        {
            CreationDate = DateOnly.FromDateTime(DateTime.Now);
            Status = FeedbackStatus.OnHold;
        }

        // for seed
        public Feedback(int id, int patientId, string text, bool isAnonymous, bool isPublic, FeedbackStatus status)
        {
            Id = id;
            PatientId = patientId;
            Text = text;
            CreationDate = new DateOnly(2022, 10, 24);
            IsAnonymous = isAnonymous;
            IsPublic = isPublic;
            Status = status;
        }

        public void SetAnonymous() => Patient = null;

    }

    public enum FeedbackStatus { OnHold, Approved, Denied }

}
