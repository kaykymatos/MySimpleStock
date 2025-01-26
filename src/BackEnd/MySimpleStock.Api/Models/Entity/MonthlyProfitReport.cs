using MySimpleStock.Api.Models.Entity;

namespace MySimpleStock.Api.Models.Entity
{
    public class MonthlyProfitReport : BaseEntity
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal TotalProfit { get; set; }
    }
}
