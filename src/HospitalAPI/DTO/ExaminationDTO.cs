using HospitalLibrary.Core.Model.ValueObjects;

namespace HospitalAPI.Web.Dto
{
    public class ExaminationDTO
    {
        public int? Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string PatientFullName { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public DateRange DateRange { get; set; }
    }
}