using Hakathon.Domain;

namespace Hakathon.Application.Repositories
{
    public interface IUserRepository
    {
        Task<string> CreateAsync(User user, CancellationToken cancellationToken);

        Task<User> GetAsync(string username, string password, CancellationToken cancellationToken);

        Task<bool> Exists(string username, CancellationToken cancellationToken);

        
    }
}
