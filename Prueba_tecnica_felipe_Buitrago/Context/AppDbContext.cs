using Microsoft.EntityFrameworkCore;
using Prueba_tecnica_felipe_Buitrago.Class;

namespace Prueba_tecnica_felipe_Buitrago.Context
{
    public class AppDbContext :DbContext
        
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Cliente> Clients { get; set; }
        public DbSet<Facturas> Bills { get; set; }
        public DbSet<Factura_Producto> Bills_Products { get; set; }
        public DbSet<Producto> Products { get; set; }
    }
}
