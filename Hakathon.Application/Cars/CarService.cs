using Hakathon.Application.Repositories;
using Hakathon.Domain;
using Mapster;

namespace Hakathon.Application.Cars
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;   
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task AddCarAsync(CarCreateDTO carCreateDTO, CancellationToken cancellationToken)
        {
            await _carRepository.AddCarAsync(carCreateDTO.Adapt<Car>(), cancellationToken);
        }

        public async Task<IEnumerable<CarCreateDTO>> GetCarsAsync(int userId,CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetCarsAsync(userId,cancellationToken);
            return car.Select(car => car.Adapt<CarCreateDTO>());
        }
    }
}
