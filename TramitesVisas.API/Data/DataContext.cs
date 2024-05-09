using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Emit;
using TramitesVisas.Shared.Entidades;

namespace TramitesVisas.API.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<Visa> Visas { get; set; }
        public DbSet<Renovacion> Renovaciones { get; set; }
        public DbSet<Historial> Historiales { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
