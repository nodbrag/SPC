using System;
using System.Collections.Generic;

namespace SPC.Models.DataModel
{
    public partial class Role
    {
        public Role()
        {
            UserRole = new HashSet<UserRole>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}