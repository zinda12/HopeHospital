using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Service
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public Address Create(Address address) => _addressRepository.Create(address);

        public void Delete(int id) => _addressRepository.Delete(id);

        public List<Address> GetAll() => _addressRepository.GetAll();

        public Address GetById(int id) => _addressRepository.GetById(id);

        public void Update(Address address) => _addressRepository.Update(address);

    }
}
