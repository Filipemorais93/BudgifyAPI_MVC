using System;
using System.Collections.Generic;

namespace BudifyAPI.Users.Models.TransactionsModel.DBTransactions;

public partial class Category
{
    public Guid IdCategory { get; set; }

    public string Name { get; set; } = null!;

    public Guid? IdUser { get; set; }
}
