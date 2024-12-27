namespace MyGoodStock.Api.Models.ViewModel
{
    public class StockMovementViewModel : BaseViewModel
    {
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public string MovementType { get; set; }
        public Guid UserId { get; set; }
    }
}
