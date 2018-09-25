using System;
using System.Collections.Generic;

namespace OrganizationDemo.Data.Models
{
    public partial class AppUser
    {
        public AppUser()
        {
            Permission = new HashSet<Permission>();
            Profile = new HashSet<Profile>();
        }

        public string Id { get; set; }
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string DisplayName { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; }
        public bool Active { get; set; }
        public string Address { get; set; }
        public DateTime BirthDay { get; set; }
        public string OrgId { get; set; }
        public string RoleId { get; set; }

        public Organization Org { get; set; }
        public Role Role { get; set; }
        public UserGroup UserGroup { get; set; }
        public ICollection<Permission> Permission { get; set; }
        public ICollection<Profile> Profile { get; set; }
    }
}
