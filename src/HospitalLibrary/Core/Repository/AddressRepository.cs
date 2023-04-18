using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;

namespace HospitalLibrary.Core.Repository
{
    public class AddressRepository : BaseEntityModelRepository<Address>, IAddressRepository
    {
        public AddressRepository(HospitalDbContext dbContext) : base(dbContext)
        {

        }
    }
}
