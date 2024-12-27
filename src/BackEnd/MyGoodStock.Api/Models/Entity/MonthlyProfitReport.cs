namespace MyGoodStock.Api.Models.Entity
{
    public class MonthlyProfitReport : BaseEntity
    {
        public DateTime Month { get; set; }
        public decimal TotalProfit { get; set; }
        public Guid UserId { get; set; }
    }
}
