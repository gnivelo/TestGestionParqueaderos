using AccesoDatos.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public partial class GenericDbContext : DbContext
    {
        public GenericDbContext()
        {
        }

        public GenericDbContext(DbContextOptions<GenericDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Caja> Caja { get; set; }
        public virtual DbSet<Registro> Registro { get; set; }
        public virtual DbSet<Vehiculo> Vehiculo { get; set; }


protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=GestionParqueadero;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Nombres).IsUnicode(false);
                entity.Property(e => e.Apellidos).IsUnicode(false);
                entity.Property(e => e.Direccion).IsUnicode(false);
                entity.Property(e => e.Email).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.NombreUsuario).IsUnicode(false);
                entity.Property(e => e.Clave).IsUnicode(false);
            });

            modelBuilder.Entity<Caja>(entity =>
            {
                entity.Property(e => e.IdCliente).IsUnicode(false);
                entity.Property(e => e.IdRegistro).IsUnicode(false);
                entity.Property(e => e.Fecha).IsUnicode(false);
                entity.Property(e => e.Valor).IsUnicode(false);
            });

            modelBuilder.Entity<Registro>(entity =>
            {
                entity.Property(e => e.PlacaVehiculo).IsUnicode(false);
                entity.Property(e => e.FechaIngreso).IsUnicode(false);
                entity.Property(e => e.FechaSalida).IsUnicode(false);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.Property(e => e.MarcaVehiculo).IsUnicode(false);
                entity.Property(e => e.ModeloVehiculo).IsUnicode(false);
                entity.Property(e => e.ColorVehiculo).IsUnicode(false);
                entity.Property(e => e.TipoVehiculo).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
