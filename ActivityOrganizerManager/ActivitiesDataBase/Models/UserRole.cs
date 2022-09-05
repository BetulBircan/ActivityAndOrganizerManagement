using System;
using System.Collections.Generic;

namespace ActivitiesDataBase.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            Organizers = new HashSet<Organizer>();
            Subscribers = new HashSet<Subscriber>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<Organizer> Organizers { get; set; }
        public virtual ICollection<Subscriber> Subscribers { get; set; }
    }
}
