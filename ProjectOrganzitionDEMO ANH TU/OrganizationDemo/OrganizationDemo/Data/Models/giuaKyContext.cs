using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OrganizationDemo.Data.Models
{
    public partial class giuaKyContext : DbContext
    {
        public giuaKyContext()
        {
        }

        public giuaKyContext(DbContextOptions<giuaKyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppUser> AppUser { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<OrgServicesRent> OrgServicesRent { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<PermissionDefaultRole> PermissionDefaultRole { get; set; }
        public virtual DbSet<PermissionServiceGroup> PermissionServiceGroup { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<UserGroup> UserGroup { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=baitapgiuaky1997.database.windows.net;Database=giuaKy;User Id=kuthinh@baitapgiuaky1997;Password=Thinh1997;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BirthDay).HasDefaultValueSql("('0001-01-01T00:00:00.000')");

                entity.Property(e => e.OrgId)
                    .HasColumnName("org_id")
                    .HasMaxLength(450);

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasMaxLength(450);

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppUser)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("FK__AppUser__org_id__0697FACD");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AppUser)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__AppUser__role_id__6FB49575");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__AspNetRol__RoleI__719CDDE7");
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__AspNetUse__UserI__72910220");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__AspNetUse__UserI__73852659");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__AspNetUse__RoleI__74794A92");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__AspNetUse__UserI__756D6ECB");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__AspNetUse__UserI__76619304");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.Property(e => e.GroupId).ValueGeneratedNever();

                entity.Property(e => e.GroupIdChildren)
                    .HasColumnName("Group_id_children")
                    .HasMaxLength(450);

                entity.Property(e => e.GroupName).HasMaxLength(100);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.OrgId)
                    .HasColumnName("Org_id")
                    .HasMaxLength(450);

                entity.Property(e => e.RoleId)
                    .HasColumnName("Role_Id")
                    .HasMaxLength(450);

                entity.HasOne(d => d.GroupIdChildrenNavigation)
                    .WithMany(p => p.InverseGroupIdChildrenNavigation)
                    .HasForeignKey(d => d.GroupIdChildren)
                    .HasConstraintName("FK__Group__Group_id___793DFFAF");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.Group)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("FK__Group__Org_id__7755B73D");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Group)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Group__Role_Id__7849DB76");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(e => e.IdOrganization);

                entity.Property(e => e.IdOrganization).ValueGeneratedNever();

                entity.Property(e => e.DisplayNameDb)
                    .HasColumnName("DisplayNameDB")
                    .HasMaxLength(100);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.NameOrganization).HasMaxLength(100);
            });

            modelBuilder.Entity<OrgServicesRent>(entity =>
            {
                entity.HasKey(e => e.OrgServiceRentId);

                entity.ToTable("org_services_rent");

                entity.Property(e => e.OrgServiceRentId)
                    .HasColumnName("org_service_rent_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ContractSignedDate).HasColumnName("contractSignedDate");

                entity.Property(e => e.ContractType).HasColumnName("contractType");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LicenseAvailable).HasColumnName("license__available");

                entity.Property(e => e.LicenseUsed).HasColumnName("license__used");

                entity.Property(e => e.LincenseAmount).HasColumnName("lincenseAmount");

                entity.Property(e => e.OrgId)
                    .HasColumnName("Org_id")
                    .HasMaxLength(450);

                entity.Property(e => e.ServiceId)
                    .HasColumnName("Service_id")
                    .HasMaxLength(450);

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.OrgServicesRent)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("FK__org_servi__Org_i__7A3223E8");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.OrgServicesRent)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__org_servi__Servi__7B264821");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId)
                    .HasColumnName("Account_ID")
                    .HasMaxLength(450);

                entity.Property(e => e.LicensedCertifate)
                    .HasColumnName("licensedCertifate")
                    .HasMaxLength(100);

                entity.Property(e => e.OrgServiceRentId)
                    .HasColumnName("Org_service_rent_id")
                    .HasMaxLength(450);

                entity.Property(e => e.Policy)
                    .HasColumnName("policy")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Permission)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Permissio__Accou__7E02B4CC");

                entity.HasOne(d => d.OrgServiceRent)
                    .WithMany(p => p.Permission)
                    .HasForeignKey(d => d.OrgServiceRentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Permissio__Org_s__7EF6D905");
            });

            modelBuilder.Entity<PermissionDefaultRole>(entity =>
            {
                entity.ToTable("PermissionDefault_Role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrgSerRentId)
                    .HasColumnName("org_ser_rent_id")
                    .HasMaxLength(450);

                entity.Property(e => e.Overridable).HasColumnName("overridable");

                entity.Property(e => e.Policy)
                    .HasColumnName("policy")
                    .HasMaxLength(450);

                entity.Property(e => e.RoleId)
                    .HasColumnName("Role_id")
                    .HasMaxLength(450);

                entity.HasOne(d => d.OrgSerRent)
                    .WithMany(p => p.PermissionDefaultRole)
                    .HasForeignKey(d => d.OrgSerRentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Permissio__org_s__01D345B0");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PermissionDefaultRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Permissio__Role___02C769E9");
            });

            modelBuilder.Entity<PermissionServiceGroup>(entity =>
            {
                entity.ToTable("Permission_Service_Group");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GroupId)
                    .HasColumnName("group_id")
                    .HasMaxLength(450);

                entity.Property(e => e.OrgSerRentId)
                    .HasColumnName("Org_ser_rent_id")
                    .HasMaxLength(450);

                entity.Property(e => e.Policy)
                    .HasColumnName("policy")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.PermissionServiceGroup)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Permissio__group__7FEAFD3E");

                entity.HasOne(d => d.OrgSerRent)
                    .WithMany(p => p.PermissionServiceGroup)
                    .HasForeignKey(d => d.OrgSerRentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Permissio__Org_s__00DF2177");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasIndex(e => e.IdentityId);

                entity.Property(e => e.OrgId).HasColumnName("org_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Identity)
                    .WithMany(p => p.Profile)
                    .HasForeignKey(d => d.IdentityId)
                    .HasConstraintName("FK__Profile__Identit__03BB8E22");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleId)
                    .HasColumnName("Role_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NameRole).HasMaxLength(100);
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.Idservice);

                entity.Property(e => e.Idservice)
                    .HasColumnName("IDService")
                    .ValueGeneratedNever();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ServiceName).HasMaxLength(450);
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("User_Group");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.GroupId)
                    .IsRequired()
                    .HasColumnName("Group_Id")
                    .HasMaxLength(450);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.UserGroup)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__User_Grou__Group__04AFB25B");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserGroup)
                    .HasForeignKey<UserGroup>(d => d.UserId)
                    .HasConstraintName("FK__User_Grou__User___05A3D694");
            });
        }
    }
}
