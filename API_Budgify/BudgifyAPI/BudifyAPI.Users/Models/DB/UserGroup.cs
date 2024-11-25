using System;
using System.Collections.Generic;

namespace BudifyAPI.Users.Models.DB;

public partial class UserGroup
{
    public Guid IdUserGroup { get; set; }

    public string Name { get; set; } = null!;
}
