namespace GrilsRide.Web.Models
{
    public class Cartao
    {
        public int CartaoId { get; set; }
        public string nrCartao { get; set; }
        public DateTime validade { get; set; }
        public int cvv { get; set; }
        public string nomeImpresso { get; set; }


        public IList<Cartao> Cartoes { get; set; }




    }
}
