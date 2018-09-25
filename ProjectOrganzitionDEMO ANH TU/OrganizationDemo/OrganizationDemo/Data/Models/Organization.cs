using System;
using System.Collections.Generic;

namespace OrganizationDemo.Data.Models
{
    public partial class Organization
    {
        public Organization()
        {
            AppUser = new HashSet<AppUser>();
            Group = new HashSet<Group>();
            OrgServicesRent = new HashSet<OrgServicesRent>();
        }

        public string IdOrganization { get; set; }
        public string NameOrganization { get; set; }
        public string DisplayNameDb { get; set; }
        public int Id { get; set; }

        public ICollection<AppUser> AppUser { get; set; }
        public ICollection<Group> Group { get; set; }
        public ICollection<OrgServicesRent> OrgServicesRent { get; set; }
    }
}
