using Microsoft.EntityFrameworkCore;
using OrganizationDemo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDemo.ManageOrganData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {

        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public  DbSet<Group> Group { get; set; }
        public  DbSet<Organization> Organization { get; set; }
        public  DbSet<OrgServicesRent> OrgServicesRent { get; set; }
        public  DbSet<Permission> Permission { get; set; }
        public  DbSet<PermissionDefaultRole> PermissionDefaultRole { get; set; }
        public  DbSet<PermissionServiceGroup> PermissionServiceGroup { get; set; }
        public  DbSet<Profile> Profile { get; set; }
        public  DbSet<Role> Role { get; set; }
        public  DbSet<Services> Services { get; set; }
        public  DbSet<UserGroup> UserGroup { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

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
