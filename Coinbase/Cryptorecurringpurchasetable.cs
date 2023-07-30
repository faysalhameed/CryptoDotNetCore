using System;
using System.Collections.Generic;

namespace Coinbase;

public partial class Cryptorecurringpurchasetable
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public int Cryptowalletid { get; set; }

    public string Coinname { get; set; } = null!;

    public string Coinamount { get; set; } = null!;

    public int Ccprofileid { get; set; }

    public DateTime Recurringpurchasestartdate { get; set; }

    public DateTime Recurringpurchaseenddate { get; set; }

    public string Recurringpurchasefrequency { get; set; } = null!;

    public DateTime Createddate { get; set; }

    public DateTime Modifieddate { get; set; }

    public int Createdbyid { get; set; }

    public int Modifiedbyid { get; set; }
}
