#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace OneToMany.Models;
public class Car
{
    [Key]
    public int CarId { get; set; }
    [Required]
    public int OwnerId {get;set;} // FOREIGN KEY
    [Required]
    public string Model { get; set; } 
    [Required]
    public string Make { get; set; } 
    [Range(1800,2023)]
    public int Year { get; set; }
    [Required]
    public string Color { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    // Navigation
    public Owner? Owner {get;set;}
}
