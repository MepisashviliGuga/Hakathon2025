using Hakathon.Application.Cars;
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
        public async Task<IActionResult> AddCard([FromBody] CarCreateDTO card, CancellationToken cancellationToken)
        {
            if (card == null)
                return BadRequest("Invalid data.");
            await _carService.AddCarAsync(card, cancellationToken);
            return Ok();
        }
    }
}
