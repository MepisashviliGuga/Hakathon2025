using Hakathon.Application.Repositories;
using Hakathon.Domain;
using Mapster;

namespace Hakathon.Application.Cards
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public async Task AddCard(CardCreateDTO card, CancellationToken cancellationToken)
        {
            await _cardRepository.AddCard(card.Adapt<Card>(), cancellationToken);
        }

        public async Task AddMoney(CardCreateDTO card, CancellationToken cancellationToken)
        {
            await _cardRepository.UpdateCard(card.Adapt<Card>(), cancellationToken);
        }

        public async Task<IEnumerable<CardCreateDTO>> GetUserCardsAsync(int userId, CancellationToken cancellationToken)
        {
            var cards = await _cardRepository.GetUserCardAsync(userId, cancellationToken);
            return cards.Select(x => x.Adapt<CardCreateDTO>());
        }
    }
}
