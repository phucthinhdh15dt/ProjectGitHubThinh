using System;
using System.Collections.Generic;

namespace OrganizationDemo.Data.Models
{
    public partial class Services
    {
        public Services()
        {
            OrgServicesRent = new HashSet<OrgServicesRent>();
        }

        public int Id { get; set; }
        public string Idservice { get; set; }
        public string ServiceName { get; set; }

        public ICollection<OrgServicesRent> OrgServicesRent { get; set; }
    }
}
