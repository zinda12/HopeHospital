using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Address : BaseEntityModel
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }

        public Address(int id,string country, string city, string street, string number)
        {
            Id = id;
            Country = country;
            City = city;
            Street = street;
            Number = number;
        }
    }
}
