using System;
using System.Collections.Generic;

namespace BudifyAPI.Users.Models.USers.DBUsers;

public partial class UserGroup
{
    public Guid IdUserGroup { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
