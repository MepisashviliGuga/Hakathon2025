using Hakathon.Application.Cards;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Hakathon.API.infrastructure.PresentationDTOs;
using Mapster;
using Hakathon.API.infrastructure.validators;
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
        public async Task<IActionResult> AddCard([FromBody] CardDTO card, CancellationToken cancellationToken)
        {
            var validator = new CardDTOValidator();
            if (card == null||!validator.Validate(card).IsValid)
                return BadRequest("Invalid data.");
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;                            
            var cardcreate = card.Adapt<CardCreateDTO>();
            cardcreate.UserId = int.Parse(userIdClaim);
            await _cardService.AddCard(cardcreate, cancellationToken);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> AddMoney([FromBody] CardDTO card, CancellationToken cancellationToken)
        {
            var validator = new CardDTOValidator();
            if (card == null || !validator.Validate(card).IsValid)
                return BadRequest("Invalid data.");
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;            
            var cardcreate = card.Adapt<CardCreateDTO>();
            cardcreate.UserId = int.Parse(userIdClaim);
            await _cardService.AddMoney(cardcreate,cancellationToken);
            return Ok();
        }
    }
}
