#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace OneToMany.Models;
public class Owner
{
    [Key]
    public int OwnerId { get; set; }
    [Required]
    public string Name { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    // Navigation Property
    public List<Car> CarsOwned {get;set;} = new List<Car>();
}
