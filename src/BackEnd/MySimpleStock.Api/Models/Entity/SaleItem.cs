using MySimpleStock.Api.Models.Entity;

namespace MySimpleStock.Api.Models.Entity
{
    public class SaleItem : BaseEntity
    {
        public Guid SaleId { get; set; }
        public Sale Sale { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
