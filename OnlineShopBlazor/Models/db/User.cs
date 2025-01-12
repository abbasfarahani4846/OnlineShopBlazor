using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopBlazor.Models.Db;

public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Email { get; set; } = null!;

    [StringLength(50)]
    public string FullName { get; set; } = null!;

    [StringLength(50)]
    public string Password { get; set; } = null!;

    public bool IsAdmin { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RegisterDate { get; set; }

    public int? RecoveryCode { get; set; }
}
