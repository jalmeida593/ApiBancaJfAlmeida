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
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<CuentasCliente> cuentasclientes { get; set; }
        public DbSet<Movimientos> movimientosc { get; set; }
        public DbSet<Persona_cliente> persona { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona_cliente>().HasKey(x => new { x.idPersona, x.idCliente });

            modelBuilder.Entity<Cliente>()
               .HasKey(x => new { x.idCliente });

            base.OnModelCreating(modelBuilder);
        }
    }
}
