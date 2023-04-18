using AutoMapper;
using HospitalAPI.Security.Models;
using HospitalAPI.Web.Dto;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Feedback, FeedbackDTO>()
                .ForMember(f => f.PatientFullName, o => o.MapFrom(f => f.Patient.FullName));

            CreateMap<Feedback, PublicFeedbackDTO>()
                .ForMember(f => f.PatientFullName, o => o.MapFrom(f => f.Patient.FullName));

            CreateMap<Examination, ExaminationDTO>()
                .ForMember(e => e.PatientFullName, o => o.MapFrom(f => f.Patient.FullName));

            CreateMap<RegisterUserDTO, Patient>()
                .ForMember(f => f.Allergens, o => o.MapFrom(f => f.Allergens));

            CreateMap<CreateFeedbackDTO, Feedback>();
            CreateMap<Allergen, AllergenDTO>();
            CreateMap<AllergenDTO, Allergen>();
            CreateMap<Patient, PatientDTO>();
            CreateMap<Doctor, DoctorDTO>();
            CreateMap<Doctor, DoctorDTO>();
            CreateMap<DoctorDTO, Doctor>();
            CreateMap<AvailableAppointments, AvailableAppointmentsDTO>();
            CreateMap<AvailableAppointmentsDTO, AvailableAppointments>();
            CreateMap<ExaminationDTO, Examination>();

            CreateMap<Examination, ViewExaminationDTO>()
                .ForMember(o => o.DoctorFullName, b => b.MapFrom(z => z.Doctor.FullName))
                .ForMember(o => o.RoomName, b => b.MapFrom(z => z.Room.Name))
                .ForMember(o => o.StartTime, b => b.MapFrom(z => z.DateRange.Start));

        }

    }
}
