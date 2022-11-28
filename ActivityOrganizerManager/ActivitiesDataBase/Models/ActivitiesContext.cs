using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ActivitiesDataBase.Models
{
    public partial class ActivitiesContext : DbContext
    {
        public ActivitiesContext()
        {
        }

        public ActivitiesContext(DbContextOptions<ActivitiesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activitiy> Activitiys { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;
        public virtual DbSet<UserMailPassword> UserMailPasswords { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = .; Database = Activities; Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activitiy>(entity =>
            {
                entity.HasKey(e => e.ActivityId)
                    .HasName("PK_Activity");

                entity.ToTable("Activitiy");

                entity.Property(e => e.ActivityDate).HasColumnType("datetime");

                entity.Property(e => e.ActivityName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.ApplicationDeadline).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Isticked)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(7, 2)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Activitiys)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activitiy_Category");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Activitiys)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activitiy_City");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Activitiys)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Activitiy_Companies");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).ValueGeneratedOnAdd();

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyEmail).IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.WebSite).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserEmail).IsUnicode(false);

                entity.Property(e => e.UserPassword).IsUnicode(false);

                entity.HasMany(d => d.Activities)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserActivity",
                        l => l.HasOne<Activitiy>().WithMany().HasForeignKey("ActivityId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UserActivity_Activitiy"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UserActivity_Users1"),
                        j =>
                        {
                            j.HasKey("UserId", "ActivityId");

                            j.ToTable("UserActivity");
                        });
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserDetail");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.PasswordAgain).IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserSurname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserDetails)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserDetail_UserRole");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserDetail)
                    .HasForeignKey<UserDetail>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserDetail_Users");
            });

            modelBuilder.Entity<UserMailPassword>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserMailPassword");

                entity.Property(e => e.UserEmail).HasColumnType("text");

                entity.Property(e => e.UserPassWord).HasColumnType("text");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("UserRole");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
