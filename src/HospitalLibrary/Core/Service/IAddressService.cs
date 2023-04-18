using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface IAddressService
    {
        public List<Address> GetAll();
        public Address GetById(int id);
        public Address Create(Address address);
        public void Update(Address address);
        public void Delete(int id);
    }
}
