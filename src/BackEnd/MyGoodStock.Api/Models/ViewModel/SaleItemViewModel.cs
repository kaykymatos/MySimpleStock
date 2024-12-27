namespace MyGoodStock.Api.Models.ViewModel
{
    public class SaleItemViewModel : BaseViewModel
    {
        public int SaleId { get; set; }
        public SaleViewModel Sale { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Guid UserId { get; set; }
    }
}
