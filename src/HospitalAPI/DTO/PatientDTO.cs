using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.DTO
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Pin { get; set; }
        public Gender Gender { get; set; }
        public BloodType BloodType { get; set; }
        public int SelectedDoctorId { get; set; }
    }

}
