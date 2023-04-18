using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model.ValueObjects;

namespace HospitalLibrary.Core.Model
{
    public class Examination : BaseEntityModel
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public DateRange DateRange { get; set; }
        public ExaminationStatus Status { get; set; }

        public Examination()
        {
        }

        public Examination(int id, int doctorId, int patientId, int roomId, ExaminationStatus status = ExaminationStatus.UPCOMING)
        {
            Id = id;
            DoctorId = doctorId;
            PatientId = patientId;
            RoomId = roomId;
            Status = status;
        }

        public Examination(int id, int doctorId, int patientId, int roomId, DateRange dateRange, ExaminationStatus status = ExaminationStatus.UPCOMING)
        {
            Id = id;
            DoctorId = doctorId;
            PatientId = patientId;
            RoomId = roomId;
            DateRange = dateRange;
            Status = status;
        }
    }
}