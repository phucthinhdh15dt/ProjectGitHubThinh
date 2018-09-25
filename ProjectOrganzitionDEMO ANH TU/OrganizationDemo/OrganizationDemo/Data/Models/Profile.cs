using System;
using System.Collections.Generic;

namespace OrganizationDemo.Data.Models
{
    public partial class Profile
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime BirthDay { get; set; }
        public string FirstName { get; set; }
        public string IdentityId { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string OrgId { get; set; }
        public string RoleId { get; set; }

        public AppUser Identity { get; set; }
    }
}
