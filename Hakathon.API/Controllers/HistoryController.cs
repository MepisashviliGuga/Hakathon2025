using Microsoft.AspNetCore.Mvc;
using Hakathon.Application.Histories;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
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
        public async Task<IActionResult> CreateHistory([FromBody] HistoryCreateDTO historyDto, CancellationToken cancellationToken)
        {
            if (historyDto == null)
                return BadRequest("Invalid data.");

            await _historyService.CreateHistoryAsync(historyDto, cancellationToken);
            return Ok(new { Message = "History entry created successfully." });
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