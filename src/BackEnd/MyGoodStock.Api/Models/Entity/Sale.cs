namespace MyGoodStock.Api.Models.Entity
{
    public class Sale : BaseEntity
    {
        public DateTime Date { get; set; }
        public decimal TotalValue { get; set; }
        public ICollection<SaleItem> SaleItems { get; set; }
        public Guid UserId { get; set; }
    }
}
