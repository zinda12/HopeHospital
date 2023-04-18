using HospitalLibrary.Core.Enums;

namespace HospitalAPI.DTO
{
    public class ViewExaminationDTO
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public string DoctorFullName { get; set; }
        public int RoomId { get; set; }
        public int FloorId { get; set; }
        public string RoomName { get; set; }
        public ExaminationStatus Status { get; set; }  
    }

}
