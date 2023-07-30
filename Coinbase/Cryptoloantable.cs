using System;
using System.Collections.Generic;

namespace Coinbase;

public partial class Cryptoloantable
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public string Cryptowalletid { get; set; } = null!;

    public string Coinname { get; set; } = null!;

    public string Coinamount { get; set; } = null!;

    public DateTime Loanstartdate { get; set; }

    public DateTime Loanenddate { get; set; }

    public string Loadfrequency { get; set; } = null!;

    public int Ccprofileid { get; set; }

    public DateTime Createddate { get; set; }

    public DateTime Modifieddate { get; set; }

    public int Createdbyid { get; set; }

    public int Modifiedbyid { get; set; }
}
