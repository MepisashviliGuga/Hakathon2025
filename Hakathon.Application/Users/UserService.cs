using Hakathon.Application.Repositories;
using Hakathon.Application.Users.Requests;
using Hakathon.Domain;
using System.Security.Cryptography;
using System.Text;
using Mapster;
using Hakathon.Application.Exceptions;

namespace Hakathon.Application.Users
{
    public class UserService : IUserService
    {
        const string SECRET_KEY = "asldij23324";
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> AuthenticationAsync(string username, string password, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAsync(username,GenerateHash(password),cancellationToken);
            if (result == null) throw new InvalidUserNameOrPasswordException("Your Credentials did not match");
            return result.Id;
        }

        public async Task<string> CreateAsync(UserCreateModel userModel, CancellationToken cancellationToken)
        {
            var exists = await _repository.Exists(userModel.Username,cancellationToken);
            if (exists)
            {
                throw new UserAlreadyExistsException("Choose different Id");
            }

            var user = userModel.Adapt<User>();
            user.Password = GenerateHash(user.Password);
            var result = await _repository.CreateAsync(user, cancellationToken);

            return result;
        }

        private string GenerateHash(string input)
        {
            using (SHA512 sha = SHA512.Create())
            {
                byte[] bytes = Encoding.ASCII.GetBytes(input + SECRET_KEY);
                byte[] hashBytes = sha.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}
