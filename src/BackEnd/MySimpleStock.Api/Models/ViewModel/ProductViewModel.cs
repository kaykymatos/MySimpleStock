using MySimpleStock.Api.Models.ViewModel;

namespace MySimpleStock.Api.Models.ViewModel
{
    public class ProductViewModel : BaseViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int QuantityInStock { get; set; }
    }
}
