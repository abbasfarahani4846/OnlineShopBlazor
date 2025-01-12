using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopBlazor.Models.Db;

[Table("Coupon")]
public partial class Coupon
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Code { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Discount { get; set; }
}
