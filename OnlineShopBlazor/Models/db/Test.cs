using System;
using System.Collections.Generic;

namespace OnlineShopBlazor.Models.Db;

public partial class Test
{
    public int Id { get; set; }

    public int Count { get; set; }

    public string Title { get; set; } = null!;
}
