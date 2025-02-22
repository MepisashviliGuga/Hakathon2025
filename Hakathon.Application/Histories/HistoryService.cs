using Hakathon.Application.Cards;
using Hakathon.Application.Cars;
using Hakathon.Application.Repositories;
using Hakathon.Domain;
using Mapster;

namespace Hakathon.Application.Histories
{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository _repository;
        private readonly ICardService _cardService;
        private readonly ICarService _carService;
        public HistoryService(IHistoryRepository repository,ICardService cardService,ICarService carService)
        {
            _repository = repository;
            _cardService = cardService;
            _carService = carService;
        }
        public async Task<int> CreateHistoryAsync(HistoryCreateDTO historyDto, CancellationToken cancellationToken)
        {
            var history = new History 
            {                
                Date = DateTime.UtcNow,
                KilometersDriven = null,
                AmountPaid = null,
                UserId = historyDto.UserId,
                CarId = historyDto.CarId,
                CardId = historyDto.CardId
            };
            await _repository.AddHistoryAsync(history,cancellationToken);
            return history.Id;
        }

        public async Task EndRidingAsync(int HistoryId, double km, CancellationToken cancellationToken)
        {
            var History = await _repository.GetHistoryAsync(HistoryId, cancellationToken);
            History.EndDate = DateTime.UtcNow;
            History.KilometersDriven = km;
            History.AmountPaid = Convert.ToDecimal(km * 2);
            await _repository.UpdateHistoryAsync(History, cancellationToken);
            var cards = await _cardService.GetUserCardsAsync(History.UserId, cancellationToken);
            var card = cards.SingleOrDefault(c => c.CardNumber == History.Card.CardNumber).Adapt<CardCreateDTO>();
            card.Balance -= History.AmountPaid.Value;            
            await _cardService.AddMoney(card,cancellationToken);
        }

        public async Task<IEnumerable<HistoryDTO>> GetUserHistoryAsync(int userId, CancellationToken cancellationToken)
        {
            var res = await _repository.GetUserHistoryAsync(userId, cancellationToken);
            return res.Select(h => h.Adapt<HistoryDTO>());
        }

    }
}