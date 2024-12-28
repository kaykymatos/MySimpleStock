using MyGoodStock.Api.Models.Entity;

namespace MyGoodStock.Api.Models.ViewModel
{
    public class SaleViewModel : BaseViewModel
    {
        public DateTime Date { get; set; }
        public decimal TotalValue { get; set; }
        public ICollection<SaleItemViewModel> SaleItems { get; set; }
    }
}
