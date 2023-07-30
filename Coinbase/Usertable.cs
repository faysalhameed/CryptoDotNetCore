using System;
using System.Collections.Generic;

namespace Coinbase;

public partial class Usertable
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Age { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Emailaddress { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Password { get; set; } = null!;
}
