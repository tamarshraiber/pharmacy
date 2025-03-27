using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Project.API.Models.Pharmacist;
using Project.API.Models.Pharmacy;
using Project.Core.Model;
using Project.Core.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IPatientsQueueService _patientsQueueService;
        private readonly ISpecialsQueueService _specialsQueueService;
        private readonly IPharmacyService _pharmacyService;

        public UpdateController(IConfiguration configuration,
            IPatientsQueueService patientsQueueService,
            ISpecialsQueueService specialsQueueService,
            IPharmacyService pharmacyService)
        {
            _configuration = configuration;
            _patientsQueueService = patientsQueueService;
            _specialsQueueService = specialsQueueService;
            _pharmacyService = pharmacyService;
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Pharmacies(int id)
        {
            try
            {
                _patientsQueueService.DeleteAll(id);
                _specialsQueueService.DeleteAll(id);
                var l = _pharmacyService.GetById(id);
                _pharmacyService.UpdateDatabase(l);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating database: {ex.Message}");
            }
        }
    }

}



