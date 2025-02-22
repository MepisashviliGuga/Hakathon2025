namespace Hakathon.Application.Exceptions
{
    public class InvalidUserNameOrPasswordException:Exception
    {
        public string Code = "Invalid UserName or Password";
        public InvalidUserNameOrPasswordException(string message):base(message)
        {
            
        }
    }
}
