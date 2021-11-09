using Microsoft.EntityFrameworkCore;

namespace RegistroVisitas.WebAPI.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Visita> Visitas { get; set; }
        public DbSet<Recepcionista> Recepcionistas { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
    }
}
