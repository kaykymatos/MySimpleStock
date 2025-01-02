using MySimpleStock.Api.Models.ViewModel;

namespace MySimpleStock.Api.Models.ViewModel
{
    public class SaleViewModel : BaseViewModel
    {
        public DateTime Date { get; set; }
        public decimal TotalValue { get; set; }
        public Guid ClientId { get; set; }
        public ICollection<SaleItemViewModel> SaleItems { get; set; }
    }
}
