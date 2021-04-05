using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GymBuddySite.Models
{
    public partial class GymBuddyDBContext : DbContext
    {
        public GymBuddyDBContext()
        {
        }

        public GymBuddyDBContext(DbContextOptions<GymBuddyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Maxlift> Maxlifts { get; set; }
        public virtual DbSet<WorkOutProgram> WorkOutPrograms { get; set; }
        public virtual DbSet<Workout> Workouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               // optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=GymBuddyDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.WorkOutId, "UQ__Categori__E39159D64DE3EBCA")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(30);

                entity.Property(e => e.WorkOutId).HasColumnName("WorkOutID");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Customer__1788CCAC1D6432F0");

                entity.HasIndex(e => e.ProgramId, "UQ__Customer__752560392925771C")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(70)
                    .HasColumnName("First Name");

                entity.Property(e => e.Height).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.LastName)
                    .HasMaxLength(70)
                    .HasColumnName("Last Name");

                entity.Property(e => e.Maxlifts).HasColumnName("MAXLifts");

                entity.Property(e => e.ProgramId).HasColumnName("ProgramID");

                entity.Property(e => e.Weight).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.MaxliftsNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.Maxlifts)
                    .HasConstraintName("FK__Customers__MAXLi__2D27B809");
            });

            modelBuilder.Entity<Maxlift>(entity =>
            {
                entity.HasKey(e => e.MaxliftsId)
                    .HasName("PK__MAXLifts__9621AC4125B96C71");

                entity.ToTable("MAXLifts");

                entity.Property(e => e.MaxliftsId)
                    .ValueGeneratedNever()
                    .HasColumnName("MAXLiftsID");

                entity.Property(e => e.MaxBench).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.MaxDeadLift).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.MaxSquat).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.WorkoutId).HasColumnName("WorkoutID");

                entity.HasOne(d => d.Workout)
                    .WithMany(p => p.Maxlifts)
                    .HasForeignKey(d => d.WorkoutId)
                    .HasConstraintName("FK__MAXLifts__Workou__2E1BDC42");
            });

            modelBuilder.Entity<WorkOutProgram>(entity =>
            {
                entity.HasKey(e => e.ProgramId)
                    .HasName("PK__WorkOutP__75256038523B87D8");

                entity.ToTable("WorkOutProgram");

                entity.Property(e => e.ProgramId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProgramID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Days).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(90);

                entity.Property(e => e.Title).HasMaxLength(80);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.WorkOutPrograms)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__WorkOutPr__Categ__2F10007B");
            });

            modelBuilder.Entity<Workout>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Weight).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.WorkoutId).HasColumnName("WorkoutID");

                entity.HasOne(d => d.WorkoutNavigation)
                    .WithMany(p => p.Workouts)
                    .HasPrincipalKey(p => p.WorkOutId)
                    .HasForeignKey(d => d.WorkoutId)
                    .HasConstraintName("FK__Workouts__Workou__300424B4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
