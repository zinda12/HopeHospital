using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface IFeedbackRepository : IEntityRepository<Feedback>
    {
        public List<Feedback> GetAllPublic();
        public List<Feedback> GetAllApprovedPublic();

    }
}
