using Hakathon.Application.Cards;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hakathon.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }
        [HttpGet("user")]
        public async Task<IActionResult> GetUserCards(CancellationToken cancellationToken)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
                return Unauthorized("User ID not found in token.");

            if (!int.TryParse(userIdClaim, out int userId))
                return Unauthorized("Invalid user ID.");

            var cards = await _cardService.GetUserCardsAsync(userId, cancellationToken);
            return Ok(cards);
        }
        [HttpPost]
        public async Task<IActionResult> AddCard([FromBody] CardCreateDTO card, CancellationToken cancellationToken)
        {
            if (card == null)
                return BadRequest("Invalid data.");
            await _cardService.AddCard(card, cancellationToken);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> AddMoney([FromBody] CardCreateDTO card, CancellationToken cancellationToken)
        {
            await _cardService.AddMoney(card,cancellationToken);
            return Ok();
        }
    }
}
