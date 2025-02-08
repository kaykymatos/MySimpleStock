using System.Text.Json.Serialization;

namespace MySimpleStock.Api.Models.ViewModel
{
    public class ClientViewModel : BaseViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<SaleViewModel> Sales { get; set; }
    }
}