using System;
using System.Collections.Generic;

namespace Coinbase;

public partial class Settingtable
{
    public int Id { get; set; }

    public string Settingkey { get; set; } = null!;

    public string Settingvalue { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime Createddate { get; set; }

    public DateTime Modifieddate { get; set; }

    public int Createdbyid { get; set; }

    public int Modifiedbyid { get; set; }
}
