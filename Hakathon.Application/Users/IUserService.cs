using Hakathon.Application.Users.Requests;
namespace Hakathon.Application.Users
{
    public interface IUserService
    {
        Task<int> AuthenticationAsync(string username, string password, CancellationToken cancellationToken);
        
        Task<string> CreateAsync(UserCreateModel user, CancellationToken cancellationToken);

    }
}
