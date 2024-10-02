using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IMedicalTest.Model;

public partial class TestImedicalContext : DbContext
{
    public TestImedicalContext()
    {
    }

    public TestImedicalContext(DbContextOptions<TestImedicalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Clima> Climas { get; set; }

    public virtual DbSet<Historico> Historicos { get; set; }

    public virtual DbSet<Noticium> Noticia { get; set; }

    public virtual DbSet<TipoBusquedum> TipoBusqueda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=test_Imedical;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ciudad__3213E83F3BE6ADE2");

            entity.ToTable("Ciudad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Latitud)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("latitud");
            entity.Property(e => e.Longitud)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("longitud");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Clima>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clima__3213E83F9B607345");

            entity.ToTable("Clima");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CiudadId).HasColumnName("ciudad_id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.Humedad)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("humedad");
            entity.Property(e => e.Precipitacion)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("precipitacion");
            entity.Property(e => e.Temperatura)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("temperatura");
            entity.Property(e => e.VelocidadViento)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("velocidad_viento");
            entity.Property(e => e.Visibilidad)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("visibilidad");

            entity.HasOne(d => d.Ciudad).WithMany(p => p.Climas)
                .HasForeignKey(d => d.CiudadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clima__ciudad_id__3C69FB99");
        });

        modelBuilder.Entity<Historico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Historic__3213E83F605BB880");

            entity.ToTable("Historico");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CiudadId).HasColumnName("ciudad_id");
            entity.Property(e => e.Hora)
                .HasColumnType("datetime")
                .HasColumnName("hora");
            entity.Property(e => e.TipoBusquedaId).HasColumnName("tipo_busqueda_id");

            entity.HasOne(d => d.Ciudad).WithMany(p => p.Historicos)
                .HasForeignKey(d => d.CiudadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Historico__ciuda__4222D4EF");

            entity.HasOne(d => d.TipoBusqueda).WithMany(p => p.Historicos)
                .HasForeignKey(d => d.TipoBusquedaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Historico__tipo___412EB0B6");
        });

        modelBuilder.Entity<Noticium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Noticia__3213E83F867B4DE2");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Autor)
                .HasMaxLength(100)
                .HasColumnName("autor");
            entity.Property(e => e.CiudadId).HasColumnName("ciudad_id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Titulo)
                .HasMaxLength(200)
                .HasColumnName("titulo");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");
            entity.Property(e => e.UrlImagen)
                .HasMaxLength(255)
                .HasColumnName("url_imagen");

            entity.HasOne(d => d.Ciudad).WithMany(p => p.Noticia)
                .HasForeignKey(d => d.CiudadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Noticia__ciudad___398D8EEE");
        });

        modelBuilder.Entity<TipoBusquedum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoBusq__3213E83F66562882");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(100)
                .HasColumnName("tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
