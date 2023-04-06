using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class UserTbl
{
    public Guid Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}
