using System;
using System.Collections.Generic;

namespace ActivitiesDataBase.Models
{
    public partial class UserMailPassword
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; } = null!;
        public string UserPassWord { get; set; } = null!;
    }
}
