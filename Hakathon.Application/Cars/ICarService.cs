namespace Hakathon.Application.Cars
{
    public interface ICarService
    {
        Task AddCarAsync(CarCreateDTO carCreateDTO,CancellationToken cancellationToken);
        Task<IEnumerable<CarCreateDTO>> GetCarsAsync(int userId,CancellationToken cancellationToken);
    }
}
