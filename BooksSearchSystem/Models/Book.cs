using System;
using System.Collections.Generic;

namespace BooksSearchSystem.Models;

public partial class Book
{
    public string Isbn { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public DateOnly? PublishedDate { get; set; }

    public string? Publisher { get; set; }

    public string? Genre { get; set; }
}
