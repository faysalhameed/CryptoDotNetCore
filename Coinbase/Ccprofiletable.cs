using System;
using System.Collections.Generic;

namespace Coinbase;

public partial class Ccprofiletable
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public string Ccnumber { get; set; } = null!;

    public DateTime Expirydate { get; set; }

    public string Profiletoken { get; set; } = null!;

    public DateTime Createddate { get; set; }

    public DateTime Modifieddate { get; set; }

    public int Createdbyid { get; set; }

    public int Modifiedbyid { get; set; }

    public string? Cvv { get; set; }
}
