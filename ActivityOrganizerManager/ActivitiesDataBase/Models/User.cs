using System;
using System.Collections.Generic;

namespace ActivitiesDataBase.Models
{
    public partial class User
    {
        public User()
        {
            Activities = new HashSet<Activitiy>();
        }

        public int UserId { get; set; }
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;

        public virtual UserDetail UserDetail { get; set; } = null!;

        public virtual ICollection<Activitiy> Activities { get; set; }
    }
}
