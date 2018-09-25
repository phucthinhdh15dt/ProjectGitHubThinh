using System;
using System.Collections.Generic;

namespace OrganizationDemo.Data.Models
{
    public partial class PermissionDefaultRole
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string OrgSerRentId { get; set; }
        public string Policy { get; set; }
        public bool? Overridable { get; set; }

        public OrgServicesRent OrgSerRent { get; set; }
        public Role Role { get; set; }
    }
}
