namespace MyGoodStock.Api.Models.Entity
{
    public class Sale : BaseEntity
    {
        public DateTime Date { get; set; }
        public decimal TotalValue { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public ICollection<SaleItem> SaleItems { get; set; }
    }
}
