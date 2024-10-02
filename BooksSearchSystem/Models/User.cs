using System;
using System.Collections.Generic;

namespace BooksSearchSystem.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;
}
