using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.API.Models.Pharmacist;
using Project.API.Models.Station;
using Project.Core.DTOs;
using Project.Core.Model;
using Project.Core.Service;
using Project.Service;
using static System.Collections.Specialized.BitVector32;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StationController : ControllerBase
    {

        private readonly IStationService _stationService;
        private readonly IPharmacyService _pharmacyService;
        private readonly IMapper _mapper;

        public StationController(IStationService stationService, IMapper mapper
            , IPharmacyService pharmacyService)
        {
            _stationService = stationService;
            _mapper = mapper;
            _pharmacyService = pharmacyService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Get()
        {
            var list = _stationService.GetAll();
            if (list == null)
            {
                return NotFound();
            }
            var listDto = _mapper.Map<List<StationDto>>(list);
            return Ok(listDto);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Pharmacist")]
        public IActionResult Get(int id)
        {
            var station = _stationService.GetById(id);
            if (station == null)
            {
                return NotFound();
            }
            var stationDto = _mapper.Map<StationDto>(station);
            return Ok(stationDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] long pharmacyId)
        {
            if (pharmacyId == null)
            {
                return BadRequest();
            }
            var p = _pharmacyService.GetById(pharmacyId);
            if (p == null)
            {
                return BadRequest();
            }
            var s = _stationService.AddStation(new Station(pharmacyId));
            if (s == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StationDto>(s));

        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Pharmacist")]
        public IActionResult Put(int id, [FromBody] StationPutModel station)
        {
            if (id != station.id)
            {
                return Conflict();
            }


            var i = _stationService.GetById(id);
            if (i == null)
            {
                return NotFound();
            }
            if (!i.isActive || i.isActive && i.pharmacistId == station.pharmacistId)
            {
                i.pharmacistId = station.pharmacistId;
                var s = _stationService.UpdateStation(id, i);
                if (s == null)
                {
                    return BadRequest();
                }
                return Ok(_mapper.Map<StationDto>(s));
            }
            return BadRequest();

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var i = _stationService.GetById(id);

            if (i == null)
            {
                return NotFound();
            }
            _stationService.Delete(id);
            return NoContent();
        }

        [HttpGet("byPharmacy/{id}")]
        [Authorize(Roles = "Admin, Pharmacist")]
        public IActionResult GetStationsByPharmacy(long id)
        {
            var s = _stationService.GetStationByPharmacy(id);
            if (s == null)
            {
                return NotFound();
            }
            return Ok(s);

        }

    }
}
