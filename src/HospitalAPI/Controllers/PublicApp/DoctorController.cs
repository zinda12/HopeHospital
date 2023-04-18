using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.PublicApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;

        public DoctorController(IDoctorService doctorService,IPatientService patientService, IMapper mapper)
        {
            _doctorService = doctorService;
            _patientService= patientService;
            _mapper = mapper;
        }

        // GET: api/Doctor
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.Map<List<DoctorDTO>>(_doctorService.GetAll()));
        }

        [HttpGet("generalPracticioners")]
        public ActionResult GetAllGeneralPracticioners()
        {
            return Ok(_mapper.Map<List<DoctorDTO>>(_doctorService.GetAllGeneralPracticioners()));
        }

        /*[HttpGet("availableGeneralPracticioners")]
        public ActionResult GetAllAvailableGeneralPracticioners()
        {
            var generalPracticioners=_doctorService.GetAllGeneralPracticioners().ToList();
            var availableGeneralPracticioners = new List<Doctor>();
            var patients = new List<Patient>();
            int minPatientsNumber = 10;
            Doctor doctorWithMinPatients = null;
            foreach(Doctor doctor in generalPracticioners)
            {
                patients = _patientService.GetBySelectedDoctorId(doctor.Id);
                if (minPatientsNumber > patients.Count()) {

                    minPatientsNumber = patients.Count();
                    doctorWithMinPatients = doctor;
                }     
            }
            availableGeneralPracticioners.Add(doctorWithMinPatients);
            generalPracticioners.Remove(doctorWithMinPatients);
            foreach (Doctor doctor in generalPracticioners)
            {
                patients = _patientService.GetBySelectedDoctorId(doctor.Id);
                if (minPatientsNumber >= patients.Count() - 2)
                {
                    availableGeneralPracticioners.Add(doctor);
                }
            }
            return Ok(_mapper.Map<List<DoctorDTO>>(availableGeneralPracticioners));
        }*/

        [HttpGet("specialization")]
        public ActionResult<List<DoctorDTO>> GetDoctorsBySpecialization([FromQuery]DoctorSpecialization specialization)
        {
            var doctors = _doctorService.GetBySpecialization(specialization);
            return Ok(_mapper.Map<List<DoctorDTO>>(doctors));
        }

    }
}
