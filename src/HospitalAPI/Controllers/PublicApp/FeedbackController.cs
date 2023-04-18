using AutoMapper;
using HospitalAPI.DTO;
using HospitalAPI.Security;
using HospitalAPI.Security.Models;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HospitalAPI.Controllers.PublicApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFeedbackService _feedbackService;
        private readonly IPatientService _patientService;
        private readonly UserManager<User> _userManager;

        public FeedbackController(IFeedbackService feedbackService, IMapper mapper,
            UserManager<User> userManager, IPatientService patientService)
        {
            _patientService = patientService;
            _userManager = userManager;
            _mapper = mapper;
            _feedbackService = feedbackService;
        }
        

        [HttpGet("public")]
        public ActionResult GetApprovedPublicFeedback()
        {
            return Ok(_mapper.Map<List<PublicFeedbackDTO>>(_feedbackService.GetAllApprovedPublic()));
        }

        [HttpGet]
        [Route ("{id}")]
        public ActionResult Get(int id)
        {
            var feedback = _feedbackService.GetById(id);
            if(feedback is not null && feedback.IsPublic == true)
            {
                return Ok(_mapper.Map<PublicFeedbackDTO>(feedback));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Patient")]
        public ActionResult CreateFeedback(CreateFeedbackDTO feedbackDTO)
        {
            var userId = User.UserId();
            var patient = _patientService.GetByUserId(userId);
            var feedback = _mapper.Map<Feedback>(feedbackDTO);
            feedback.PatientId = patient.Id;
            var newFeedback = _feedbackService.Create(feedback);
            return CreatedAtAction(nameof(Get), new { id = newFeedback.Id }, _mapper.Map<PublicFeedbackDTO>(newFeedback));
        }
    }
}
