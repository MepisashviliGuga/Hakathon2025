using Microsoft.AspNetCore.Mvc;
using Hakathon.Application.Histories;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Mapster;
using Hakathon.API.infrastructure.PresentationDTOs;
using Hakathon.API.infrastructure.validators;
namespace Hakathon.API.Controllers
{

    [Authorize] 
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EndRide(int id, [FromBody] int km,CancellationToken cancellationToken) 
        {
            await _historyService.EndRidingAsync(id, km, cancellationToken);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CreateHistory([FromBody] HistoryRequestDTO historyDto, CancellationToken cancellationToken)
        {
            var validator = new HistoryRequestDTOValidator();
            if (historyDto == null||!validator.Validate(historyDto).IsValid)
                return BadRequest("Invalid data.");
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var historycreate = historyDto.Adapt<HistoryCreateDTO>();
            historycreate.UserId = int.Parse(userIdClaim);
            int id = await _historyService.CreateHistoryAsync(historycreate, cancellationToken);
            return Ok(id);
        }
        
        [HttpGet("user")]
        public async Task<IActionResult> GetUserHistory(CancellationToken cancellationToken)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
                return Unauthorized("User ID not found in token.");

            if (!int.TryParse(userIdClaim, out int userId))
                return Unauthorized("Invalid user ID.");

            var history = await _historyService.GetUserHistoryAsync(userId, cancellationToken);
            return Ok(history);
        }
    }
}