using System;
using System.Collections.Generic;

namespace Coinbase;

public partial class Transactiontable
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public DateTime Transactiondate { get; set; }

    public string Paymentsource { get; set; } = null!;

    public string Paymentsourceid { get; set; } = null!;

    public string Paymentsourcecurrency { get; set; } = null!;

    public string Transactiontype { get; set; } = null!;

    public string Transactionamount { get; set; } = null!;

    public DateTime Createddate { get; set; }

    public int Createdbyid { get; set; }
}
