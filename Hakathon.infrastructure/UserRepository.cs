using Hakathon.Application.Repositories;
using Hakathon.Domain;
using Microsoft.Extensions.Options;
using Hakathon.persistance.context;
using Microsoft.EntityFrameworkCore;
namespace Hakathon.infrastructure
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(HakathonContext context):base(context)
        {
            
        }
        public async Task<string> CreateAsync(User user, CancellationToken cancellationToken)
        {
            await base.AddAsync(cancellationToken,user);
            return user.Username;
        }

        public async Task<bool> Exists(string username, CancellationToken cancellationToken)
        {
            return await base.AnyAsync(cancellationToken,x=>x.Username == username);
        }
        public async Task<User?> GetAsync(string username, string password, CancellationToken cancellationToken)
        {
            var user = await _dbSet.FirstOrDefaultAsync(user => user.Username == username, cancellationToken);

            if (user == null || user.Password != password)
                return null;

            return user;
        }      
    }
}