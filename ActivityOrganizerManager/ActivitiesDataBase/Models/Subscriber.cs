using System;
using System.Collections.Generic;

namespace ActivitiesDataBase.Models
{
    public partial class Subscriber
    {
        public int SubscriberId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserSurname { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string UserPasswordAgain { get; set; } = null!;
        public int RoleId { get; set; }
        public string? IsAgree { get; set; }
    }
}
