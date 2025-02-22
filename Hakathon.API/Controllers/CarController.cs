using Hakathon.API.infrastructure.PresentationDTOs;
using Hakathon.API.infrastructure.validators;
using Hakathon.Application.Cards;
using Hakathon.Application.Cars;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hakathon.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        
        [HttpGet("user")]
        public async Task<IActionResult> GetUserCars(CancellationToken cancellationToken)
        {            
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
                return Unauthorized("User ID not found in token.");

            if (!int.TryParse(userIdClaim, out int userId))
                return Unauthorized("Invalid user ID.");

            var cars = await _carService.GetCarsAsync(userId, cancellationToken);
            return Ok(cars);
        }
        [HttpPost]
        public async Task<IActionResult> AddCard([FromBody] CarDTO car, CancellationToken cancellationToken)
        {
            var validator = new CarDTOValidator();
            if (car == null|| !validator.Validate(car).IsValid)
                return BadRequest("Invalid data.");                        
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var carcreate = car.Adapt<CarCreateDTO>();
            carcreate.UserId = int.Parse(userIdClaim);
            await _carService.AddCarAsync(carcreate, cancellationToken);
            return Ok();
        }
    }
}
