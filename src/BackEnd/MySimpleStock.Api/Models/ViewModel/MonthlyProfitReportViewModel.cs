namespace MySimpleStock.Api.Models.ViewModel
{
    public class MonthlyProfitReportViewModel : BaseViewModel
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal TotalProfit { get; set; }
    }
}
