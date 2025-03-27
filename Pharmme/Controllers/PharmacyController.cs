using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.API.Models.Pharmacist;
using Project.API.Models.Pharmacy;
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
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyService _pharmacyService;
        private readonly IMapper _mapper;
        private readonly IStationService _stationService;

        public PharmacyController(IPharmacyService pharmacyService, IMapper mapper,
            IStationService stationService)
        {
            _pharmacyService = pharmacyService;
            _mapper = mapper;
            _stationService = stationService;
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Get()
        {
            var list = _pharmacyService.GetAll();
            if (list == null)
                return NotFound();
            var listDto = _mapper.Map<List<PharmacyDto>>(list);
            return Ok(listDto);
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Get(long id)
        {
            var pharmacy = _pharmacyService.GetById(id);
            if (pharmacy == null)
                return NotFound();
            var pharmacyDto = _mapper.Map<PharmacyDto>(pharmacy);
            return Ok(pharmacyDto);
        }




        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(long id, [FromBody] PharmacyPutModel pharmacy)
        {
            var p = _mapper.Map<PharmacyDto>(_pharmacyService.UpdatePharmacy(id, _mapper.Map<Pharmacy>(pharmacy)));
            if (p == null)
                return BadRequest(p);
            return Ok(p);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public IActionResult Delete(long id)
        {
            var p = _pharmacyService.Delete(id);
            if (p == null)
                return NotFound();
            return NoContent();
        }


        [HttpPost("patient/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddPatientToQ(long id)
        {
            var p = _pharmacyService.AddPatientToQ(id).Result;
            if (p == null)
                return BadRequest();
            return Ok(p.addCounter);
        }

        [HttpPost("special/{id}")]
        [Authorize(Roles = "Admin")]

        public IActionResult AddSpecialToQ(long id)
        {
            var p = _pharmacyService.AddSpecialToQ(id).Result;
            if (p == null)
                return BadRequest();
            return Ok(p.specialsAddCounter);
        }

        [HttpDelete("removePatient/{id}")]
        [Authorize(Roles = "Pharmacist")]
        public IActionResult RemovePatient(long id)
        {
            var i = _pharmacyService.GetById(id);
            if (i == null)
                return NotFound();
            var p = _pharmacyService.RemovePatient(id).Result;
            if (p == -1)
            {
                return BadRequest();
            }
            return Ok(p);
        }


    }
}
