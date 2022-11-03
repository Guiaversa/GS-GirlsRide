using GrilsRide.Web.Controllers;
using GrilsRide.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace GrilsRide.Web.Percistencia
{
    public class GrilsRideContext : DbContext
    {
        public GrilsRideContext(DbContextOptions op):base(op)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
