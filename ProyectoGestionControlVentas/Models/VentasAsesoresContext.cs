using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoGestionControlVentas.Models;

public partial class VentasAsesoresContext : DbContext
{
    public VentasAsesoresContext()
    {
    }

    public VentasAsesoresContext(DbContextOptions<VentasAsesoresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tarea> Tareas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PK__Tarea__756A5402EB26BC17");

            entity.ToTable("Tarea");

            entity.Property(e => e.IdTarea).HasColumnName("idTarea");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
