namespace MyGoodStock.Api.Models.ViewModel
{
    public class MonthlyProfitReportViewModel : BaseViewModel
    {
        public int Month { get; set; }
        public decimal TotalProfit { get; set; }
    }
}
