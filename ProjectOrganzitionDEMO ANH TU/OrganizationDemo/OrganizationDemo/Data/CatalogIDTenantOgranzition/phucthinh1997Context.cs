using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OrganizationDemo.Data.CatalogIDTenantOgranzition
{
    public partial class phucthinh1997Context : DbContext
    {
        public phucthinh1997Context()
        {
        }

        public phucthinh1997Context(DbContextOptions<phucthinh1997Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CatalogOrganzitionTenant> CatalogOrganzitionTenant { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=phucthinh1997.database.windows.net;Database=phucthinh1997;User Id=phucthinh1997@phucthinh1997;Password=Thinh1997;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogOrganzitionTenant>(entity =>
            {
                entity.HasKey(e => new { e.IdtenantOrgranzition, e.Idorgranzition });

                entity.Property(e => e.IdtenantOrgranzition).HasColumnName("IDTenantOrgranzition");

                entity.Property(e => e.Idorgranzition).HasColumnName("IDOrgranzition");

                entity.Property(e => e.CatalogOrgranzitionName)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
