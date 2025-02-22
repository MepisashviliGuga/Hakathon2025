using System.Reflection;

namespace Hakathon.Application.Exceptions
{
    public class UserAlreadyExistsException:Exception
    {
        public string Code = "User Already Exception";
        public UserAlreadyExistsException(string message):base(message)
        {
            
        }
    }
}
