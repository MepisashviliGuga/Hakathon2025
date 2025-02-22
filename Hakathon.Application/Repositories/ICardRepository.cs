using Hakathon.Application.Cards;
using Hakathon.Domain;
namespace Hakathon.Application.Repositories
{
    public interface ICardRepository
    {
        Task AddCard(Card card, CancellationToken cancellationToken);
        Task UpdateCard(Card card, CancellationToken cancellationToken);
        Task<IEnumerable<Card>> GetUserCardAsync(int userId, CancellationToken cancellationToken);

    }
}