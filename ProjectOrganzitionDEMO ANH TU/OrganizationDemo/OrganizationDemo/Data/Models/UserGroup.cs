using System;
using System.Collections.Generic;

namespace OrganizationDemo.Data.Models
{
    public partial class UserGroup
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string GroupId { get; set; }

        public Group Group { get; set; }
        public AppUser User { get; set; }
    }
}
