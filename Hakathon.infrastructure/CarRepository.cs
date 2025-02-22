using Hakathon.Application.Repositories;
using Hakathon.Domain;
using Hakathon.persistance.context;
using Microsoft.EntityFrameworkCore;

namespace Hakathon.infrastructure
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(HakathonContext hakathonContext) : base(hakathonContext) { }

        public async Task AddCarAsync(Car car, CancellationToken cancellationToken)
        {
            await base.AddAsync(cancellationToken,car);
        }

        public async Task<IEnumerable<Car>> GetCarsAsync(int userId, CancellationToken cancellationToken)
        {
            return await _dbSet
                .Where(c => c.UserId == userId).ToListAsync(cancellationToken);
                
        }
    }
}
