namespace Hakathon.Application.Cards
{
    public interface ICardService
    {
        Task AddMoney(CardCreateDTO card, CancellationToken cancellationToken);
        Task AddCard(CardCreateDTO card, CancellationToken cancellationToken);
        Task<IEnumerable<CardCreateDTO>> GetUserCardsAsync(int userId,CancellationToken cancellationToken);
    }
}
