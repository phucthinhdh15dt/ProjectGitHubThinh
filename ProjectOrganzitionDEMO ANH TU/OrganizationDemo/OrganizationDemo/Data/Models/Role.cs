using System;
using System.Collections.Generic;

namespace OrganizationDemo.Data.Models
{
    public partial class Role
    {
        public Role()
        {
            AppUser = new HashSet<AppUser>();
            Group = new HashSet<Group>();
            PermissionDefaultRole = new HashSet<PermissionDefaultRole>();
        }

        public int Id { get; set; }
        public string RoleId { get; set; }
        public int? Priority { get; set; }
        public string NameRole { get; set; }
        public string Description { get; set; }

        public ICollection<AppUser> AppUser { get; set; }
        public ICollection<Group> Group { get; set; }
        public ICollection<PermissionDefaultRole> PermissionDefaultRole { get; set; }
    }
}
