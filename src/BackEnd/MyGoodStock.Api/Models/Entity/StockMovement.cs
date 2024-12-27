namespace MyGoodStock.Api.Models.Entity
{
    public class StockMovement : BaseEntity
    {
        public Guid ProductId { get; set; }
        public StockMovement Product { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public string MovementType { get; set; }
        public Guid UserId { get; set; }
    }
}
