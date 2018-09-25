using System;
using System.Collections.Generic;

namespace OrganizationDemo.Data.Models
{
    public partial class Permission
    {
        public int Id { get; set; }
        public string OrgServiceRentId { get; set; }
        public string AccountId { get; set; }
        public string LicensedCertifate { get; set; }
        public string Policy { get; set; }

        public AppUser Account { get; set; }
        public OrgServicesRent OrgServiceRent { get; set; }
    }
}
