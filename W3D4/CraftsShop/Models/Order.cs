#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CraftsShop.Models;

public class Order
{
    [Key]
    public int OrderId { get; set; }
    [Required]
    public int UserId { get; set; }
    public User? User { get; set; }
    [Required]
    public int CraftId { get; set; }
    public Craft? Craft { get; set; }
    [Required]
    public int QuantityOrdered { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}