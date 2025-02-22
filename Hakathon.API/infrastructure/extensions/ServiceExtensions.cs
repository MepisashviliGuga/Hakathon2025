using Hakathon.Application.Cards;
using Hakathon.Application.Cars;
using Hakathon.Application.Histories    ;
using Hakathon.Application.Repositories;
using Hakathon.Application.Users;
using Hakathon.infrastructure;
namespace Hakathon.API.infrastructure.extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services) 
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IHistoryRepository, HistoryRepository>();
            services.AddScoped<IHistoryService, HistoryService>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICarService, CarService>();
        }
    }
}
