using System;
using System.Collections.Generic;

namespace OnlineShopBlazor.Models.Db;

public partial class Banner
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? ImageName { get; set; }

    public int? Priority { get; set; }

    public string? Link { get; set; }

    public string? Position { get; set; }
}
