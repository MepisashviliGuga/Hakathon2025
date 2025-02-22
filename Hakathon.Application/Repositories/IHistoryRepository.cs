using Hakathon.Domain;
namespace Hakathon.Application.Repositories
{
    public interface IHistoryRepository
    {
        Task<IEnumerable<History>> GetUserHistoryAsync(int userId, CancellationToken cancellationToken);
        Task AddHistoryAsync(History history, CancellationToken cancellationToken);
        Task<History> GetHistoryAsync(int HistoryId, CancellationToken cancellationToken);
        Task UpdateHistoryAsync(History history, CancellationToken cancellationToken);
    }
}
