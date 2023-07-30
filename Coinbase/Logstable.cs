using System;
using System.Collections.Generic;

namespace Coinbase;

public partial class Logstable
{
    public int Id { get; set; }

    public DateTime Logdate { get; set; }

    public string Logtype { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string Apiname { get; set; } = null!;

    public string Methodname { get; set; } = null!;

    public DateTime Createddate { get; set; }
}
