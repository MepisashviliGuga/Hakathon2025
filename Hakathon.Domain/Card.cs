namespace Hakathon.Domain
{
    public class Card
    {
        public int Id { get; set; }
        public int UserId { get; set; } 
        public string CardNumber { get; set; } 
        public decimal Balance { get; set; }
     
        public User User { get; set; }
    }
}
