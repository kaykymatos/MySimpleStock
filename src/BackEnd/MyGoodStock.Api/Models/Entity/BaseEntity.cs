namespace MyGoodStock.Api.Models.Entity
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreationDate{ get; set; }
    }
}
