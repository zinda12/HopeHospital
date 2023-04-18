using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Core.Repository
{
    public class FeedbackRepository : BaseEntityModelRepository<Feedback>, IFeedbackRepository
    {

        public FeedbackRepository(HospitalDbContext dbContext) : base(dbContext)
        {

        }

        public override List<Feedback> GetAll() => _dbContext.Feedbacks.Include(f => f.Patient).ToList();

        public override Feedback GetById(int id) => _dbContext.Feedbacks.Include(f => f.Patient).FirstOrDefault(f => f.Id == id);

        public List<Feedback> GetAllPublic() => _dbContext.Feedbacks.Include(f => f.Patient).Where(f => f.IsPublic).ToList();

        public List<Feedback> GetAllApprovedPublic() => _dbContext.Feedbacks.Include(f => f.Patient).Where(f => f.IsPublic && f.Status == FeedbackStatus.Approved).ToList();
    }
}
