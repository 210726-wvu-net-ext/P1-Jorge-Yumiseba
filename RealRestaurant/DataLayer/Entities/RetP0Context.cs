using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataLayer.Entities
{
    public partial class RetP0Context : DbContext
    {
        public RetP0Context()
        {
        }

        public RetP0Context(DbContextOptions<RetP0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("Restaurant");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cuisine)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rating).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Review>(entity =>
            {
             


                entity.ToTable("Review");
                
                entity.Property(e => e.Comments)
                    .HasMaxLength(100)
                    
                    .IsUnicode(false);

                entity.HasOne(d => d.Restaurant)
                    
                    .WithMany(p => p.Reviews)
                    
                    .HasForeignKey(d => d.RestaurantId)

                    .OnDelete(DeleteBehavior.ClientCascade)
                    .HasConstraintName("FK__Review__Restaura__22751F6C");

                entity.HasOne(d => d.User)

                    .WithMany(p => p.Reviews)
                    
                    .HasForeignKey(d => d.UserId)
                   .OnDelete(DeleteBehavior.ClientCascade)

                    .HasConstraintName("FK__Review__UserId__2180FB33");
                    
            });

            OnModelCreatingPartial(modelBuilder);
           
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
