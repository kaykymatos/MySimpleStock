using MyGoodStock.Api.Models.Entity;

namespace MyGoodStock.Api.Models.ViewModel
{
    public class SaleViewModel : BaseViewModel
    {
        public DateTime Date { get; set; }
        public decimal TotalValue { get; set; }
        public Guid UserId { get; set; }
    }
}
