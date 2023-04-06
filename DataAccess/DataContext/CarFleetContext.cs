using System;
using System.Collections.Generic;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataContext;

public partial class CarFleetContext : DbContext
{
    public CarFleetContext()
    {
    }

    public CarFleetContext(DbContextOptions<CarFleetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CarTbl> CarTbls { get; set; }

    public virtual DbSet<ColorTbl> ColorTbls { get; set; }

    public virtual DbSet<MakeTbl> MakeTbls { get; set; }

    public virtual DbSet<ModelTbl> ModelTbls { get; set; }

    public virtual DbSet<UserTbl> UserTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarTbl>(entity =>
        {
            entity.ToTable("Car_tbl");

            entity.Property(e => e.ColorId).HasColumnName("Color_Id");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MakeId).HasColumnName("Make_Id");
            entity.Property(e => e.ModelId).HasColumnName("Model_Id");
            entity.Property(e => e.Transmission)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Color).WithMany(p => p.CarTbls)
                .HasForeignKey(d => d.ColorId)
                .HasConstraintName("FK_Car_tbl_Color_tbl");

            entity.HasOne(d => d.Make).WithMany(p => p.CarTbls)
                .HasForeignKey(d => d.MakeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Car_tbl_Car_tbl");

            entity.HasOne(d => d.Model).WithMany(p => p.CarTbls)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Car_tbl_Model_tbl");
        });

        modelBuilder.Entity<ColorTbl>(entity =>
        {
            entity.ToTable("Color_tbl");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MakeTbl>(entity =>
        {
            entity.ToTable("Make_tbl");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ModelTbl>(entity =>
        {
            entity.ToTable("Model_tbl");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Make).WithMany(p => p.ModelTbls)
                .HasForeignKey(d => d.MakeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Model_tbl_Make_tbl");
        });

        modelBuilder.Entity<UserTbl>(entity =>
        {
            entity.ToTable("User_tbl");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
