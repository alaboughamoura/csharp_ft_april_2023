#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CraftsShop.Models;

public class Craft 
{
    [Key]
    public int CraftId { get; set; }
    // Foreign Key
    [Required]
    public int UserId { get; set; }
    // Navigation Property : creator
    public User? Creator { get; set; }
    [Required]
    [MinLength(3)]
    public string Title { get; set; }
    [Required]
    [Range(0.00,double.MaxValue)]
    public double Price { get; set; }
    [Required]
    public string Image { get; set; }
    [Required]
    [Range(1,int.MaxValue)]
    public int Quantity { get; set; }
    [Required]
    [MinLength(10, ErrorMessage ="You need to be more descriptive !")]
    public string Description { get; set; }
    // -----------------------Created At--------------------------------
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    // ----------------------------Updated At-------------------------------
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    // ! Navigation Properties 
    // * Orders I'm in 
    public List<Order> OrdersIn { get; set; } = new List<Order>();
}