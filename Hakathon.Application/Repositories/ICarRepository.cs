using Hakathon.Application.Cars;
using Hakathon.Domain;
namespace Hakathon.Application.Repositories
{
    public interface ICarRepository
    {
        Task AddCarAsync(Car car, CancellationToken cancellationToken);
        Task<IEnumerable<Car>> GetCarsAsync(int userId, CancellationToken cancellationToken);
    }
}
