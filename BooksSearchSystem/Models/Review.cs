using System;
using System.Collections.Generic;

namespace BooksSearchSystem.Models;

public partial class Review
{
    public string ReviewId { get; set; } = null!;

    public int UserId { get; set; }

    public string Isbn { get; set; } = null!;

    public DateOnly ReviewDate { get; set; }

    public string ReviewContent { get; set; } = null!;
}
