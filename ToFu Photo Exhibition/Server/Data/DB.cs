using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data;

public partial class DB : DbContext
{
    public DB()
    {
    }

    public DB(DbContextOptions<DB> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Round> Rounds { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("name=ConnectionStrings:DB", ServerVersion.Parse("10.11.6-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.TeamId, "Car_Team");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.CarNo).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.TeamId)
                .HasColumnType("int(11)")
                .HasColumnName("TeamID");

            entity.HasOne(d => d.Team).WithMany(p => p.Cars)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Car_Team");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CarId, "Photo_Car_idx");

            entity.HasIndex(e => e.RoundId, "Photo_Round_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.CarId)
                .HasColumnType("int(11)")
                .HasColumnName("CarID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.FilePath).HasMaxLength(1000);
            entity.Property(e => e.RoundId)
                .HasColumnType("int(11)")
                .HasColumnName("RoundID");

            entity.HasOne(d => d.Car).WithMany(p => p.Photos)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Photo_Car");

            entity.HasOne(d => d.Round).WithMany(p => p.Photos)
                .HasForeignKey(d => d.RoundId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Photo_Round");
        });

        modelBuilder.Entity<Round>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CategoryId, "Round_Category_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.CategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("CategoryID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Year).HasColumnType("int(11)");

            entity.HasOne(d => d.Category).WithMany(p => p.Rounds)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Round_Category");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CategoryId, "Team_Category_idx");

            entity.HasIndex(e => e.ManufacturerId, "Team_Manufacturer_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.CategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("CategoryID");
            entity.Property(e => e.ManufacturerId)
                .HasColumnType("int(11)")
                .HasColumnName("ManufacturerID");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Category).WithMany(p => p.Teams)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Team_Category");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Teams)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Team_Manufacturer");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
