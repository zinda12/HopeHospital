using AutoMapper;
using HospitalAPI.DTO;
using HospitalAPI.Security;
using HospitalAPI.Web.Dto;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace HospitalAPI.Controllers.PublicApp
{
    [Route("api/public/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        private readonly IExaminationService _examinationService;
        private readonly IPatientService _patientService;

        public ExaminationController(
            IMapper mapper,
            IExaminationService examinationService,
            IDoctorService doctorService,
            IPatientService patientService,
            IAppointmentService appointmentService)
        {
            _mapper = mapper;
            _examinationService = examinationService;
            _doctorService = doctorService;
            _appointmentService = appointmentService;
            _patientService = patientService;
        }

        [HttpPost]
        [Authorize(Roles = "Patient")]
        public ActionResult Create(ExaminationDTO examinationDTO)
        {
            var isFree = false;
            AvailableAppointments availableAppointments = _appointmentService.GetAvailableAppointments(examinationDTO.DateRange, examinationDTO.DoctorId);
            foreach(DateRange dr in availableAppointments.Slots)
            {
                if(dr.Start == examinationDTO.DateRange.Start &&
                    dr.End == examinationDTO.DateRange.End)
                {
                    isFree = true;
                    break;
                }
            }
            if (!isFree)
                return BadRequest();

            var userId = User.UserId();
            var patient = _patientService.GetByUserId(userId);
            examinationDTO.PatientId = patient.Id;
            var examination = _mapper.Map<Examination>(examinationDTO);
            examination.RoomId = _doctorService.GetById(examinationDTO.DoctorId).RoomId;
            _examinationService.Create(examination);
            return Ok();
        }

        [HttpGet("patient")]
        [Authorize(Roles = "Patient")]
        public ActionResult GetExaminationsForPatient()
        {
            var userId = User.UserId();
            var patient = _patientService.GetByUserId(userId);
            return Ok(_mapper.Map<List<ViewExaminationDTO>>(_examinationService.GetByPatientId(patient.Id)));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Patient")]
        public ActionResult CancelExamination(int id)
        {
            bool isCancellable = _examinationService.CheckIfCancellable(id);
            if (!isCancellable)
            {
                return Ok(isCancellable);
            }
            else
            {
                return Ok(isCancellable);
            }
        }
    }
}
