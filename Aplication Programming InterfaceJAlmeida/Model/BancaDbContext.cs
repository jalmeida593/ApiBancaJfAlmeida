using Aplication_Programming_InterfaceJAlmeida.Entities;
using Aplication_Programming_InterfaceJAlmeida.Model.Request;
using Aplication_Programming_InterfaceJAlmeida.Model.Response;
using Microsoft.EntityFrameworkCore;

namespace Aplication_Programming_InterfaceJAlmeida.Model
{
    public class BancaDbContext : DbContext
    {
        public BancaDbContext(DbContextOptions<BancaDbContext> options) : base(options)
        {

        }
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<CuentasCliente> cuentascliente { get; set; }
        public DbSet<Movimientos> movimientos { get; set; }
        public DbSet<Persona> persona { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cliente>()
               .HasKey(x => new { x.idCliente });
            
            modelBuilder.Entity<Persona>()
              .HasKey(x => new { x.idPersona });

            modelBuilder.Entity<CuentasCliente>()
             .HasKey(x => new { x.idCuentas });

            modelBuilder.Entity<Movimientos>()
            .HasKey(x => new { x.idMovimientos });

            base.OnModelCreating(modelBuilder);
        }
    }
}
