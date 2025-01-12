using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopBlazor.Models.Db;

[Table("Test")]
public partial class Test
{
    [Key]
    public int Id { get; set; }

    [Column("count")]
    public int Count { get; set; }

    [Column("title")]
    [StringLength(50)]
    public string Title { get; set; } = null!;
}
