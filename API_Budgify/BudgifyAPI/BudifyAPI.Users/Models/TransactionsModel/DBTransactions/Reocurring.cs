﻿using System;
using System.Collections.Generic;

namespace BudifyAPI.Users.Models.TransactionsModel.DBTransactions;

public partial class Reocurring
{
    public Guid IdReocurring { get; set; }

    public Guid IdWallet { get; set; }

    public Guid? IdCategory { get; set; }

    public Guid? IdSubcategory { get; set; }

    public string Description { get; set; } = null!;

    public float Amount { get; set; }

    public int? DayOfWeek { get; set; }

    public DateOnly StartDate { get; set; }

    public bool IsYearly { get; set; }

    public bool IsMonthly { get; set; }

    public bool IsWeekly { get; set; }

    public bool IsActive { get; set; }
}
