using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopBlazor.Models.Db;

public partial class OrderDetail
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string ProductTitle { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal ProductPrice { get; set; }

    public int Count { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }
}
