namespace ToFu_Photo_Exhibition.Server.Models;

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

	public virtual DbSet<TeamInformation> TeamInformations { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlServer("name=ConnectionStrings:DB");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Car>(entity =>
		{
			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.Name)
				.HasMaxLength(50)
				.IsUnicode(false);
			entity.Property(e => e.TeamInformationId).HasColumnName("TeamInformationID");

			entity.HasOne(d => d.TeamInformation).WithMany(p => p.Cars)
				.HasForeignKey(d => d.TeamInformationId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Cars_TeamInformations");
		});

		modelBuilder.Entity<Category>(entity =>
		{
			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.Name)
				.HasMaxLength(50)
				.IsUnicode(false);
		});

		modelBuilder.Entity<Manufacturer>(entity =>
		{
			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.Name)
				.HasMaxLength(50)
				.IsUnicode(false);
		});

		modelBuilder.Entity<Photo>(entity =>
		{
			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.CarId).HasColumnName("CarID");
			entity.Property(e => e.Description).IsUnicode(false);
			entity.Property(e => e.FilePath).IsUnicode(false);
			entity.Property(e => e.RoundId).HasColumnName("RoundID");

			entity.HasOne(d => d.Car).WithMany(p => p.Photos)
				.HasForeignKey(d => d.CarId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Photos_Cars");

			entity.HasOne(d => d.Round).WithMany(p => p.Photos)
				.HasForeignKey(d => d.RoundId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Photos_Rounds");
		});

		modelBuilder.Entity<Round>(entity =>
		{
			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
			entity.Property(e => e.Name)
				.HasMaxLength(50)
				.IsUnicode(false);

			entity.HasOne(d => d.Category).WithMany(p => p.Rounds)
				.HasForeignKey(d => d.CategoryId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Rounds_Categories");
		});

		modelBuilder.Entity<Team>(entity =>
		{
			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.Name)
				.HasMaxLength(50)
				.IsUnicode(false);
		});

		modelBuilder.Entity<TeamInformation>(entity =>
		{
			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
			entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");
			entity.Property(e => e.TeamId).HasColumnName("TeamID");

			entity.HasOne(d => d.Category).WithMany(p => p.TeamInformations)
				.HasForeignKey(d => d.CategoryId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_TeamInformations_Categories");

			entity.HasOne(d => d.Manufacturer).WithMany(p => p.TeamInformations)
				.HasForeignKey(d => d.ManufacturerId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_TeamInformations_Manufacturers");

			entity.HasOne(d => d.Team).WithMany(p => p.TeamInformations)
				.HasForeignKey(d => d.TeamId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_TeamInformations_Teams");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
