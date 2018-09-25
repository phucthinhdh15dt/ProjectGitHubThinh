using System;
using System.Collections.Generic;

namespace OrganizationDemo.Data.Models
{
    public partial class Group
    {
        public Group()
        {
            InverseGroupIdChildrenNavigation = new HashSet<Group>();
            PermissionServiceGroup = new HashSet<PermissionServiceGroup>();
            UserGroup = new HashSet<UserGroup>();
        }

        public int Id { get; set; }
        public string OrgId { get; set; }
        public string GroupName { get; set; }
        public string GroupIdChildren { get; set; }
        public string RoleId { get; set; }
        public string GroupId { get; set; }

        public Group GroupIdChildrenNavigation { get; set; }
        public Organization Org { get; set; }
        public Role Role { get; set; }
        public ICollection<Group> InverseGroupIdChildrenNavigation { get; set; }
        public ICollection<PermissionServiceGroup> PermissionServiceGroup { get; set; }
        public ICollection<UserGroup> UserGroup { get; set; }
    }
}
