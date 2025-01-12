using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopBlazor.Models.Db;

public partial class Product
{
    [Key]
    public int Id { get; set; }

    [Column("TItle")]
    [StringLength(500)]
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Text { get; set; }

    [Column(TypeName = "money")]
    public decimal? Price { get; set; }

    [Column(TypeName = "money")]
    public decimal? Discount { get; set; }

    [StringLength(50)]
    public string? ImageName { get; set; }

    public int? Qty { get; set; }

    public string? Tags { get; set; }

    [StringLength(100)]
    public string? Category { get; set; }
}
