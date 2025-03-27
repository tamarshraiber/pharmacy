using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Core.DTOs;
using Project.Core.Model;
using Project.Core.Service;
using Project.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialsQueueController : ControllerBase
    {
        private readonly ISpecialsQueueService _specialsQueueService;
        private readonly IMapper _mapper;


        public SpecialsQueueController(ISpecialsQueueService specialsQueueService
            , IMapper mapper)
        {
            _specialsQueueService = specialsQueueService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetListByPharmacy(long id)
        {
            var p = _specialsQueueService.GetByPharmacy(id);
            if (p == null)
            {
                return NotFound();
            }
            var pModel = _mapper.Map<List<SpecialQueueDto>>(p);
            return Ok(pModel);
        }



    }
}
