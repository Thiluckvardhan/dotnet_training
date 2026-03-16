using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace WebApi.Data.Models;
public partial class Food
{
    [Required]
    public int Id { get; set; }
    [Required,MinLength(3)]
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}
