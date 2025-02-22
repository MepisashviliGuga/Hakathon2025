namespace Hakathon.Domain
{

    public class Car
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Brand { get; set; }
        public string Serie { get; set; }
        public string CarIdentifier { get; set; }

        public User Owner { get; set; }
    }


}

