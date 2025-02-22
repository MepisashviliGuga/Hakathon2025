using Hakathon.Application.Repositories;
using Hakathon.Domain;
using Hakathon.persistance.context;
using Microsoft.EntityFrameworkCore;

namespace Hakathon.infrastructure
{
    public class HistoryRepository : BaseRepository<History>, IHistoryRepository
    {
        public HistoryRepository(HakathonContext hakathonContext) : base(hakathonContext) { }

        public async Task AddHistoryAsync(History history, CancellationToken cancellationToken)
        {
            await base.AddAsync(cancellationToken, history);
        }

        public async Task<History> GetHistoryAsync(int HistoryId, CancellationToken cancellationToken)
        {
            return await base.GetAsync(cancellationToken, HistoryId);
        }

        public async Task<IEnumerable<History>> GetUserHistoryAsync(int userId, CancellationToken cancellationToken)
        {
            return await _dbSet
                .Where(h => h.UserId == userId)
                .OrderByDescending(h => h.Date)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateHistoryAsync(History history, CancellationToken cancellationToken)
        {
            await base.UpdateAsync(cancellationToken, history);
        }
    }
}