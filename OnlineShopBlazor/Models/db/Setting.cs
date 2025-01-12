using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopBlazor.Models.Db;

public partial class Setting
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "money")]
    public decimal? Shipping { get; set; }

    [StringLength(100)]
    public string? Title { get; set; }

    [StringLength(500)]
    public string? Address { get; set; }

    [StringLength(50)]
    public string? Email { get; set; }

    [StringLength(50)]
    public string? Phone { get; set; }

    [StringLength(100)]
    public string? CopyRight { get; set; }

    [StringLength(100)]
    public string? Instagram { get; set; }

    [StringLength(100)]
    public string? FaceBook { get; set; }

    [StringLength(100)]
    public string? GooglePlus { get; set; }

    [StringLength(100)]
    public string? Youtube { get; set; }

    [StringLength(100)]
    public string? Twitter { get; set; }

    [StringLength(50)]
    public string? Logo { get; set; }
}
