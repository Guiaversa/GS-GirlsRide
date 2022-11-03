using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GrilsRide.Web.Controllers
{
    public class Cliente
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Name { get; set; }
        [Phone]
        public string Telefone { get; set; }
        public string cps { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }

    }
}
