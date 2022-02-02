using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<Users>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
