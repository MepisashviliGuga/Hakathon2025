namespace Hakathon.Application.Users.Requests
{
    public class UserCreateModel
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DriverLicenseNumber { get; set; }
    }
}
