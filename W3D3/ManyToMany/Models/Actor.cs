
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ManyToMany.Models;
public class Actor
{
    [Key]
    public int ActorId { get; set; }
    [Required]
    [MinLength(2)]
    public string Name { get; set; } 
    [Required]
    [MinLength(3)]
    public string Image { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    // - Navigation Properties
    public List<Association> MyMovies {get;set;} = new List<Association>();
}