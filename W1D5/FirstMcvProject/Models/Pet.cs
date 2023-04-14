#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace FirstMcvProject.Models;
public class Pet 
{
    [Required(ErrorMessage ="Name is required ❌❌❌")]
    public string  Name { get; set; }
    [Required(ErrorMessage = "Pet Age must be Added 😡😡😡")]
    [Range(1,30 ,ErrorMessage ="Pet Age must between 1 and 30 😡😡😡")]
    public int Age { get; set; }
    public bool IsFriendly { get; set; }
    [Required]
    public string Color { get; set; }
}