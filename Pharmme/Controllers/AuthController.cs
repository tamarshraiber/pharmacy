using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Project.API.Models.Pharmacist;
using Project.API.Models.Pharmacy;
using Project.Core.Model;
using Project.Core.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IPharmacyService _pharmacyService;
        private readonly IPharmacistService _pharmacistService;
        private readonly IStationService _stationService;

        public AuthController(IConfiguration configuration,
            IPharmacyService pharmacyService,
            IPharmacistService pharmacistService,
            IStationService stationService)
        {
            _configuration = configuration;
            _pharmacyService = pharmacyService;
            _pharmacistService = pharmacistService;
            _stationService = stationService;
        }

        [HttpPost("/PharmacyLogin")]
        public IActionResult PharmacyLogin([FromBody] PharmacyLoginModel pharmacyLoginModel)
        {

            Pharmacy p = _pharmacyService.GetByName(pharmacyLoginModel.manager);
            if (p != null && pharmacyLoginModel.password == p.password)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, p.manager),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: _configuration.GetValue<string>("JWT:Issuer"),
                    audience: _configuration.GetValue<string>("JWT:Audience"),
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString, Pharmacy = p });
            }
            return Unauthorized();
        }

        [HttpPost("/PharmacistLogin")]
        public IActionResult PharmacistLogin([FromBody] PharmacistLoginModel pharmacistLoginModel)
        {

            Pharmacist p = _pharmacistService.GetByName(pharmacistLoginModel.name);
            if (p != null && pharmacistLoginModel.password == p.password)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, p.name),
                    new Claim(ClaimTypes.Role, "Pharmacist")
                };

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: _configuration.GetValue<string>("JWT:Issuer"),
                    audience: _configuration.GetValue<string>("JWT:Audience"),
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString, Pharmacist = p });
            }
            return Unauthorized();
        }


        [HttpPost("/signup")]
        public IActionResult SignUpManager([FromBody] PharmacyPostModel model)
        {
            Pharmacy existingPharmacy = _pharmacyService.GetByName(model.manager);
            if (existingPharmacy != null)
            {
                return Conflict(new { message = "Pharmacy manager already exists." });
            }

            var newPharmacy = new Pharmacy
            {
                manager = model.manager,
                password = model.password,
                pharmacyPassword = model.pharmacyPassword,
                stationCount = model.stationCount,
                addCounter = 100,
                specialsAddCounter = 100,
                removeCounter = 100,
                specialsRemoveCounter = 100,
                stations = new List<Station>()

            };


            var p = _pharmacyService.AddPharmacy(newPharmacy);
            for (int i = 0; i < model.stationCount; i++)
            {
                _stationService.AddStation(new Station(p.id));
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, newPharmacy.manager),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("JWT:Issuer"),
                audience: _configuration.GetValue<string>("JWT:Audience"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            var newPharmacyToSend = _pharmacyService.GetByName(model.manager);
            return Ok(new { Token = tokenString, Pharmacy = newPharmacyToSend });
        }


    }
}
