using System;
using System.Collections.Generic;

namespace SPC.Models.DataModel
{
    public partial class User
    {
        public User()
        {
            UserRole = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public bool IsUsed { get; set; }
        public string Description { get; set; }
        

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}