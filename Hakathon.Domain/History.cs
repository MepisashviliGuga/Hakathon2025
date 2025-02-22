namespace Hakathon.Domain
{
    public class History
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public int CardId { get; set; } 

        public double? KilometersDriven { get; set; }
        public decimal? AmountPaid { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? EndDate { get; set; }

        
        public User User { get; set; }
        public Car Car { get; set; }
        public Card Card { get; set; }
    }

}
