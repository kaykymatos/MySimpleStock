namespace MyGoodStock.Api.Models.Entity
{
    public class MonthlyProfitReport : BaseEntity
    {
        public int Month { get; set; }
        public decimal TotalProfit { get; set; }
    }
}
