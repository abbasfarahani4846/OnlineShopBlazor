using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopBlazor.Models.Db;

[Keyless]
public partial class Testview
{
    public int ProductId { get; set; }

    public int Count { get; set; }

    [Column(TypeName = "money")]
    public decimal? Price { get; set; }

    [StringLength(50)]
    public string? ImageName { get; set; }

    [Column(TypeName = "money")]
    public decimal? Discount { get; set; }

    public int? Qty { get; set; }

    [Column("TItle")]
    [StringLength(500)]
    public string? Title { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }
}
