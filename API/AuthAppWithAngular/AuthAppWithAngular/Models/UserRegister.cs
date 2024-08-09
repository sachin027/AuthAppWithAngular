using System;
using System.Collections.Generic;

namespace AuthAppWithAngular.Models;

public partial class UserRegister
{
    public int Userid { get; set; }

    public string? Username { get; set; }

    public string? FirstName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Password { get; set; }
}
