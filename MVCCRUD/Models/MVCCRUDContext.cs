using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVCCRUD.Models
{
    public partial class MVCCRUDContext : DbContext
    {
        public MVCCRUDContext()
        {
        }

        public MVCCRUDContext(DbContextOptions<MVCCRUDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clase> Clases { get; set; } = null!;
        public virtual DbSet<Socio> Socios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("server=DESKTOP-JJRVNFN; database=MVCCRUD; integrated security= true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clase>(entity =>
            {
                entity.ToTable("Clase");

                entity.Property(e => e.DiaClase).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Profesor)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Socio>(entity =>
            {
                entity.ToTable("Socio");

                entity.Property(e => e.Dni).HasColumnName("DNI");

                entity.Property(e => e.FechaIngreso).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}