// {Title = "FIFA 23", Price = 189.99, Genre ="Sports", Rating = "A", Platform = "All"}
#pragma warning disable CS8618
namespace LinqLecture.Models;
public class Game 
{
    public string Title { get; set; }
    public double Price { get; set; }
    public string Genre { get; set; }
    public string Rating { get; set; }
    public string Platform { get; set; }
}