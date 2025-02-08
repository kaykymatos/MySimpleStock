namespace MySimpleStock.Api.Models.Entity
{
    public class Client : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public ICollection<Sale> Sales { get; set; }
    }
}
