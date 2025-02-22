namespace Hakathon.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string DriverLicenseNumber { get; set; }

        // Navigation Properties
        public ICollection<Car> Cars { get; set; } = new List<Car>();
        public ICollection<History> HistoryRecords { get; set; } = new List<History>();
        public ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}