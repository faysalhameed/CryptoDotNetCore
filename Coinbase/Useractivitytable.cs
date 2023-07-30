using System;
using System.Collections.Generic;

namespace Coinbase;

public partial class Useractivitytable
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public DateTime Startime { get; set; }

    public DateTime Endtime { get; set; }

    public string Autologout { get; set; } = null!;

    public DateTime Autologoutdate { get; set; }

    public string Source { get; set; } = null!;

    public string Ip { get; set; } = null!;

    public string Os { get; set; } = null!;

    public DateTime Createddate { get; set; }

    public DateTime Modifieddate { get; set; }

    public int Createdbyid { get; set; }

    public int Modifiedbyid { get; set; }
}
