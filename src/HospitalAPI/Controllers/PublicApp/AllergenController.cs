using AutoMapper;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.PublicApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergenController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAllergenService _allergenService;

        public AllergenController(IAllergenService allergenService, IMapper mapper)
        {
            _allergenService = allergenService;
            _mapper = mapper;
        }

        // GET: api/Allergen
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.Map<List<AllergenDTO>>(_allergenService.GetAll()));
        }
    }
}
