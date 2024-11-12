using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AOA.Connection.Entities;

public partial class News
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(32)]
    public string Title { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    [Required, MinLength(32)]
    public string ShortDescription { get; set; }
    [Required, MaxLength(128)]
    public string Content { get; set; }
    public byte[]? Photo { get; set; } = null;
    [Required, ForeignKey(nameof(UserId))]
    public int UserId { get; set; } 
    [Required]
    public User CreateUser { get; set; }
 
}
