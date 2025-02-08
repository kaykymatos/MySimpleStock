namespace MySimpleStock.Api.Models.ViewModel
{
    public class SaleViewModel : BaseViewModel
    {
        private DateTime _date; // Campo privado para armazenar o valor

        public DateTime Date
        {
            get { return _date.Date; } // Retorna a data com horas zeradas
            set { _date = value; }     // Define o valor da data
        }

        public decimal TotalValue { get; set; }
        public string ClientId { get; set; }
        public ClientViewModel Client { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<SaleItemViewModel> SaleItems { get; set; }

    }
}
