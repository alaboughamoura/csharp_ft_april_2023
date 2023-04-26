
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ManyToMany.Models;
public class Association
{
    [Key]
    public int AssociationId { get; set; }
    [Required]
    public int ActorId { get; set; }
    public Actor? Actor {get;set;}
    [Required]
    public int MovieId { get; set; } 
    public Movie? Movie {get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    // - Navigation Properties 
}