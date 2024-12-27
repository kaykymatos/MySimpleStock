namespace MyGoodStock.Api.Models.ViewModel
{
    public class MonthlyProfitReportViewModel : BaseViewModel
    {
        public DateTime Month { get; set; }
        public decimal TotalProfit { get; set; }
        public Guid UserId { get; set; }
    }
}
