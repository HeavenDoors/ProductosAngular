using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class ProductoAngularContext : DbContext
{
    public ProductoAngularContext()
    {
    }

    public ProductoAngularContext(DbContextOptions<ProductoAngularContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<SubCategorium> SubCategoria { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LaElifLaptop; Database= ProductoAngular; TrustServerCertificate=True; User ID=Elif2; Password=Elif2;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A104147B82C");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__PRODUCTO__098892105B1D2C64");

            entity.ToTable("PRODUCTOS");

            entity.Property(e => e.IdProducto).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdSubCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdSubCategoria)
                .HasConstraintName("FK__PRODUCTOS__IdSub__3C69FB99");
        });

        modelBuilder.Entity<SubCategorium>(entity =>
        {
            entity.HasKey(e => e.IdSubCategoria).HasName("PK__SubCateg__0A1EFFE5811445FA");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.SubCategoria)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__SubCatego__IdCat__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
