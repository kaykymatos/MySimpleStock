namespace MyGoodStock.Api.Models.ViewModel
{
    public class SaleItemViewModel : BaseViewModel
    {
        public Guid SaleId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
