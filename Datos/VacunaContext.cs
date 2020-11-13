using System;
using System.Collections.Generic;
using System.Text;
using Entidad;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class VacunaContext : DbContext
    {
        public VacunaContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Vacuna> Vacunas { get; set; }

        protected override void OnModelCreating(ModelBuilder constructoDeModelo)
        {
            constructoDeModelo.Entity<Vacuna>()
                    .HasOne<Persona>()
                    .WithMany()
                    .HasForeignKey(v => v.Identificacion);
        }
    }
}
