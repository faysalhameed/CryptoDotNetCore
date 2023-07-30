using System;
using System.Collections.Generic;

namespace Coinbase;

public partial class Cryptowalletdetailtable
{
    public int Id { get; set; }

    public string Cryptowalletid { get; set; } = null!;

    public string Coinname { get; set; } = null!;

    public string Coinamount { get; set; } = null!;

    public DateTime Createddate { get; set; }

    public DateTime Modifieddate { get; set; }

    public int Createdbyid { get; set; }

    public int Modifiedbyid { get; set; }
}
