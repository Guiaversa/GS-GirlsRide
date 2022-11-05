using Microsoft.AspNetCore.Mvc;

namespace GrilsRide.Web.Models
{
    public class Carro
    {
        [HiddenInput]
        public int CarroId { get; set; }
        public string ModeloCarro { get; set; }
        public string Placa { get; set; }
        public string SenhaPorta { get; set; }


        // relacionamento 1:N

        public IList<Carro> Carros { get; set; }

    }

}
