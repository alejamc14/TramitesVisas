using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Emit;
using TramitesVisas.Shared.Entidades;

namespace TramitesVisas.API.Data
{
    public class DataContext : IdentityDbContext<User>
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<TipoVisa> TipoVisas { get; set; }
        public DbSet<Renovacion> Renovaciones { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Documento> Documentos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
