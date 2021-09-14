using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TechSupport_App.Models
{
    public partial class TechSupportContext : DbContext
    {
        public TechSupportContext()
        {
        }

        public TechSupportContext(DbContextOptions<TechSupportContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Incident> Incidents { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Technician> Technicians { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["TechSupport"].
                ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.State)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ZipCode).IsUnicode(false);

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.State)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_States_Customers");
            });

            modelBuilder.Entity<Incident>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Incidents)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Incidents_Customers");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany(p => p.Incidents)
                    .HasForeignKey(d => d.ProductCode)
                    .HasConstraintName("FK_Incidents_Products");

                entity.HasOne(d => d.Tech)
                    .WithMany(p => p.Incidents)
                    .HasForeignKey(d => d.TechId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Incidents_Technicians");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.ProductCode });

                entity.Property(e => e.ProductCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Registrations_Customers");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.ProductCode)
                    .HasConstraintName("FK_Registrations_Products");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.StateCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StateName).IsUnicode(false);
            });

            modelBuilder.Entity<Technician>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
