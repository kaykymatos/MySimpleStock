namespace MyGoodStock.Api.Models.ViewModel
{
    public class StockMovementViewModel : BaseViewModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public string MovementType { get; set; }
        public Guid UserId { get; set; }
    }
}
