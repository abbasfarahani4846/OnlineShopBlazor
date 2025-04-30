using System;
using System.Collections.Generic;

namespace OnlineShopBlazor.Models.Db;

public partial class Cart
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ProductId { get; set; }

    public int Count { get; set; }
}
