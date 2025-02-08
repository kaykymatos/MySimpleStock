namespace MySimpleStock.Api.Models.ViewModel
{
    public class SaleItemViewModel : BaseViewModel
    {
        public string SaleId { get; set; }
        public string ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
