using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Core.DTOs;
using Project.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PatientsQueueController : ControllerBase
    {
        private readonly IPatientsQueueService _patientsQueueService;
        private readonly IMapper _mapper;

        public PatientsQueueController(IPatientsQueueService patientsQueueService,
            IMapper mapper)
        {
            _patientsQueueService = patientsQueueService;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public IActionResult GetListByPharmacy(long id)
        {
            var p = _patientsQueueService.GetByPharmacy(id);
            if (p == null)
            {
                return NotFound();
            }
            var pModel = _mapper.Map<List<PatientQueueDto>>(p);
            return Ok(pModel);
        }

    }
}
