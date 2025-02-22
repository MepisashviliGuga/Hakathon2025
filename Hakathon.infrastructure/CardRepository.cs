using Hakathon.Application.Repositories;
using Hakathon.Domain;
using Hakathon.persistance.context;
using Microsoft.EntityFrameworkCore;

namespace Hakathon.infrastructure
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(HakathonContext hakathonContext) : base(hakathonContext) { }


        public async Task AddCard(Card card, CancellationToken cancellationToken)
        {
            await base.AddAsync(cancellationToken,card);
        }

        public async Task<IEnumerable<Card>> GetUserCardAsync(int userId, CancellationToken cancellationToken)
        {
            return await _dbSet
                .Where(h => h.UserId == userId)
                .ToListAsync(cancellationToken);                                
        }

        public async Task UpdateCard(Card card, CancellationToken cancellationToken)
        {
            var cardnew = await _dbSet.SingleOrDefaultAsync(x => card.CardNumber == x.CardNumber);
            cardnew.Balance = card.Balance; 
            await base.UpdateAsync(cancellationToken, cardnew);
        }
    }
}
