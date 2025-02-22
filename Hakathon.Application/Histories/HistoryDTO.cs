namespace Hakathon.Application.Histories
{
    public class HistoryDTO
    {
        public int Id { get; set; }
        public double KilometersDriven { get; set; }
        public double AmountPaid { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public int CardId { get; set; }
    }
}
