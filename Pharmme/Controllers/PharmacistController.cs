using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.API.Models.Pharmacist;
using Project.Core.DTOs;
using Project.Core.Model;
using Project.Core.Service;
using Project.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PharmacistController : ControllerBase
    {
        private readonly IPharmacistService _pharmacistService;
        private readonly IMapper _mapper;

        public PharmacistController(IPharmacistService pharmacistService, IMapper mapper)
        {
            _pharmacistService = pharmacistService;
            _mapper = mapper;
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Get()
        {
            var list = _pharmacistService.GetAll();
            if (list == null)
            {
                return NotFound(null);

            }
            var listDto = _mapper.Map<List<PharmacistDto>>(list);

            return Ok(listDto);
        }



        [HttpGet("GetAcordungToPharmacy")]
        [Authorize(Roles = "Admin, Pharmacist")]
        public IActionResult GetAcordungToPharmacy(long pharmacyId)
        {
            var pharmacists = _pharmacistService.GetByPharmacyId(pharmacyId);
            if (pharmacists == null)
            {
                return NotFound();
            }
            var listDto = _mapper.Map<List<PharmacistDto>>(pharmacists);
            return Ok(listDto);

        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Pharmacist")]
        public IActionResult Get(long id)
        {
            var pharmacist = _pharmacistService.GetById(id);
            if (pharmacist == null)
            {
                return NotFound();
            }

            var pharmacistDto = _mapper.Map<PharmacistDto>(pharmacist);
            return Ok(pharmacistDto);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult Post([FromBody] PharmacistPostModel pharmacist)
        {
            return Ok(_pharmacistService.AddPharmacist(_mapper.Map<Pharmacist>(pharmacist)));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Pharmacist")]

        public IActionResult Put(long id, [FromBody] PharmacistPutModel pharmacist)
        {
            return Ok(_pharmacistService.UpdatePharmacist(id, _mapper.Map<Pharmacist>(pharmacist)));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(long id)
        {
            Pharmacist p = _pharmacistService.Delete(id);
            if (p == null)
            {
                return NotFound(null);
            }
            return NoContent();
        }


    }
}
