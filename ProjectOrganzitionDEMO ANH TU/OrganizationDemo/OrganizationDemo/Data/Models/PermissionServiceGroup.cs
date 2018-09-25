using System;
using System.Collections.Generic;

namespace OrganizationDemo.Data.Models
{
    public partial class PermissionServiceGroup
    {
        public int Id { get; set; }
        public string OrgSerRentId { get; set; }
        public string GroupId { get; set; }
        public string Policy { get; set; }

        public Group Group { get; set; }
        public OrgServicesRent OrgSerRent { get; set; }
    }
}
