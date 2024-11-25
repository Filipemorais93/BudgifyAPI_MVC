using System;
using System.Collections.Generic;

namespace BudifyAPI.Users.Models.TransactionsModel.DBTransactions;

public partial class TransactionGroup
{
    public Guid IdTransactionGroup { get; set; }

    public string Description { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public float PlannedAmount { get; set; }
}
