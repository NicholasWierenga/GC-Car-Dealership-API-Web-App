using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GC_CAR_DEALERSHIP.Models
{
    public partial class GCCarDealershipDBContext : DbContext
    {
        public GCCarDealershipDBContext()
        {
        }

        public GCCarDealershipDBContext(DbContextOptions<GCCarDealershipDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=GCCarDealershipDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.Color).HasMaxLength(12);

                entity.Property(e => e.Make).HasMaxLength(30);

                entity.Property(e => e.Model).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
