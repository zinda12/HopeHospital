using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.PublicApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(
            IMapper mapper,
            IAppointmentService appointmentService)
        {
            _mapper = mapper;
            _appointmentService = appointmentService;
        }

        [HttpGet("recommend")]
        public ActionResult<List<AvailableAppointmentsDTO>> GetRecommendedExaminationTime(
            [FromQuery] DateTime start,
            [FromQuery] DateTime end,
            [FromQuery] int doctorId,
            [FromQuery] AppointmentPriority priority)
        {
            if (start >= end)
                return BadRequest();
            var dateRange = new DateRange(start, end);
            var availableAppointments = _appointmentService.GetRecommendedAvailableAppointments(dateRange, doctorId, priority);
            return Ok(_mapper.Map<List<AvailableAppointmentsDTO>>(availableAppointments));
        }

        [HttpGet("available/doctor-date")]
        public ActionResult<AvailableAppointmentsDTO> GetAvailableAppointmentsByDateDoctor(
            [FromQuery] DateTime date,
            [FromQuery] int doctorId)
        {
            var availableAppointments = _appointmentService.GetAvailableAppointments(date, doctorId);
            return Ok(_mapper.Map<AvailableAppointmentsDTO>(availableAppointments));
        }

    }
}
