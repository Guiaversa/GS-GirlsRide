using GrilsRide.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace GrilsRide.Web.Percistencia
{
    public class GirlsRideContext : DbContext
    {
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Pagamento> pagamentos { get; set; }
       
        public GirlsRideContext(DbContextOptions op):base(op)
        {
        }

       
    }
}
