using System;
using System.Collections.Generic;

namespace ActivitiesDataBase.Models
{
    public partial class UserDetail
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserSurname { get; set; }
        public string? PasswordAgain { get; set; }
        public byte? RoleId { get; set; }

        public virtual UserRole? Role { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
