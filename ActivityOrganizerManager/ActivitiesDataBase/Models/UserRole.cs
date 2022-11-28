using System;
using System.Collections.Generic;

namespace ActivitiesDataBase.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            UserDetails = new HashSet<UserDetail>();
        }

        public byte RoleId { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<UserDetail> UserDetails { get; set; }
    }
}
