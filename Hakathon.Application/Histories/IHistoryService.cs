namespace Hakathon.Application.Histories
{
    public interface IHistoryService
    {
        Task<IEnumerable<HistoryDTO>> GetUserHistoryAsync(int userId, CancellationToken cancellationToken);
        Task<int> CreateHistoryAsync(HistoryCreateDTO historyDto, CancellationToken cancellationToken);
        Task EndRidingAsync(int HistoryId,double km, CancellationToken cancellationToken);
    }
}
