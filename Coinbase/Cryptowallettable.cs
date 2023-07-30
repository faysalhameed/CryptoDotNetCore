using System;
using System.Collections.Generic;

namespace Coinbase;

public partial class Cryptowallettable
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public string Walletaddress { get; set; } = null!;

    public string Publickey { get; set; } = null!;

    public string Privatekey { get; set; } = null!;

    public string Token { get; set; } = null!;

    public DateTime Createddate { get; set; }

    public DateTime Modifieddate { get; set; }

    public int Createdbyid { get; set; }

    public int Modifiedbyid { get; set; }
}
