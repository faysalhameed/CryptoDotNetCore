using System;
using System.Collections.Generic;

namespace Coinbase;

public partial class Cryptolocktable
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public int Cryptowalletid { get; set; }

    public string Coinname { get; set; } = null!;

    public string Coinlockamount { get; set; } = null!;

    public DateTime Lockstartdate { get; set; }

    public DateTime Lockenddate { get; set; }

    public DateTime Createddate { get; set; }

    public DateTime Modifieddate { get; set; }

    public int Createdbyid { get; set; }

    public int Modifiedbyid { get; set; }
}
