using System;
using System.Collections.Generic;

namespace OrganizationDemo.Data.Models
{
    public partial class OrgServicesRent
    {
        public OrgServicesRent()
        {
            Permission = new HashSet<Permission>();
            PermissionDefaultRole = new HashSet<PermissionDefaultRole>();
            PermissionServiceGroup = new HashSet<PermissionServiceGroup>();
        }

        public int Id { get; set; }
        public string OrgId { get; set; }
        public string ServiceId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? LincenseAmount { get; set; }
        public int? LicenseAvailable { get; set; }
        public int? LicenseUsed { get; set; }
        public DateTime? ContractSignedDate { get; set; }
        public int? ContractType { get; set; }
        public string OrgServiceRentId { get; set; }

        public Organization Org { get; set; }
        public Services Service { get; set; }
        public ICollection<Permission> Permission { get; set; }
        public ICollection<PermissionDefaultRole> PermissionDefaultRole { get; set; }
        public ICollection<PermissionServiceGroup> PermissionServiceGroup { get; set; }
    }
}
