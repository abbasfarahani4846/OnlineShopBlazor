using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopBlazor.Models.Db;

[Table("Comment")]
public partial class Comment
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string Email { get; set; } = null!;

    [StringLength(1000)]
    public string CommentText { get; set; } = null!;

    public int ProductId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreateDate { get; set; }
}
