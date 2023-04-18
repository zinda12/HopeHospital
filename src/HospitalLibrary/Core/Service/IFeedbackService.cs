using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface IFeedbackService
    {
        public List<Feedback> GetAll();
        public Feedback GetById(int id);
        public List<Feedback> GetAllPublic();
        public List<Feedback> GetAllApprovedPublic();
        public Feedback Create(Feedback feedback);
        public void Update(Feedback feedback);
        public void Delete(int id);
        public void ChangeStatus(int id, FeedbackStatus feedbackStatus);
    }
}
