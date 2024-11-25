using System;
using System.Collections.Generic;

namespace BudifyAPI.Users.Models.WalletModel.DBWallet;

public partial class Wallet
{
    public Guid IdWallet { get; set; }

    public Guid IdUser { get; set; }

    public string Name { get; set; } = null!;

    public string? Requisition { get; set; }

    public int? AgreementDays { get; set; }
}
