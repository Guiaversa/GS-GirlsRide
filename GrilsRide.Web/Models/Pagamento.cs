using Microsoft.AspNetCore.Mvc;

namespace GrilsRide.Web.Models
{
    public class Pagamento
    {
        [HiddenInput]
        public int PagamentoId { get; set; }
        public string metodoPagamento { get; set; }
        public double Total { get; set; }

    }
}
