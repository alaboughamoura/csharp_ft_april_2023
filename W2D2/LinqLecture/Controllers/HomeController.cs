using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LinqLecture.Models;

namespace LinqLecture.Controllers;

public class HomeController : Controller
{
    // {Title = "FIFA 23", Price = 189.99, Genre ="Sports", Rating = "A", Platform = "All"}
    public static int[] Numbers = new int[]{
        1,2,3,4,5
    };
    // Games Dataset that we are going to use as DB 
    public static Game[] Games = new Game[]{
        new Game {Title = "Elden Ring", Price=59.99, Genre= "Action RPG", Rating="M", Platform = "PC"},new Game {Title="League of Legends", Price=0.00, Genre="MOBA", Rating="T", Platform="PC"},
        new Game {Title="World of Warcraft", Price=39.99, Genre="MMORPG", Rating="T", Platform="PC"},
        new Game {Title="Elder Scrolls Online", Price=14.99, Genre="Action RPG", Rating="M", Platform="PC"},
        new Game {Title="Smite", Price=0.00, Genre="MOBA", Rating="T", Platform="All"},
        new Game {Title="Overwatch", Price=39.00, Genre="First-person Shooter", Rating="T", Platform="PC"},
        new Game {Title="Scarlet Nexus", Price=59.99, Genre="Action JRPG", Rating="T", Platform="All"},
        new Game {Title="Wonderlands", Price=59.99, Genre="RPG FPS", Rating="M", Platform="All"},
        new Game {Title="Rocket League", Price=0.00, Genre="Sports", Rating="E", Platform="All"},
        new Game {Title="StarCraft", Price=0.00, Genre="RTS", Rating="T", Platform="PC"},
        new Game {Title="God of War", Price=29.99, Genre="Action-adventure ", Rating="M", Platform="PC"},
        new Game{Title="Doki Doki Literature Club Plus!", Price=10.00, Genre="Casual", Rating="E", Platform="PC"},
        new Game {Title="Red Dead Redemption", Price=40.00, Genre="Action adventure", Rating="M", Platform="All"},
        new Game{Title = "FIFA 23", Price = 189.99, Genre ="Sports", Rating = "A", Platform = "All"},
        new Game{Title = "Call Of Deuty", Price = 249.99, Genre  = "Action", Rating = "A", Platform = "PC"},
        new Game{Title = "PES", Price = 109.99, Genre  = "Sports", Rating = "A", Platform = "All"},
        new Game {Title = "Battlefield", Price = 49.99, Genre = "MOBA", Rating = "B"},
        new Game {Title="My Little Pony A Maretime Bay Adventure", Price=39.99, Genre="Adventure", Rating="E",Platform="All"},
        new Game {Title="Fallout New Vegas", Price=10.00, Genre="Open World RPG", Rating="M", Platform="PC"},
        new Game {Title = "BattalField", Price = 49.99, Genre = "MOBA", Rating = "B"}
    };
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // -1 All Games
        // 1 - IEnumerable
        IEnumerable<Game> AllGamesIEnumerable = Games;
        // 2 - List
        List<Game> AllGamesList = Games.ToList();
        // Passing the data to the view using ViewBag 🎒
        ViewBag.AllGamesIEnumerable =AllGamesIEnumerable;
        ViewBag.AllGamesList =AllGamesList;
        // -2 All PC Games
        List<Game>  AllPCGames = Games.Where(g=>g.Platform == "PC").ToList();
        ViewBag.AllPCGames =AllPCGames;
        // -3 First 3 Games
        List<Game> FirstThreeGames = Games.Take(3).ToList();
        ViewBag.FirstThreeGames =FirstThreeGames;
        // -4 First 3 Free Games
        List<Game> FirstThreeFreeGames = Games.Where(h=>h.Price == 0.00).Take(3).ToList();
        ViewBag.FirstThreeFreeGames =FirstThreeFreeGames;
        // -5 All Games Ordered By Title
        List<Game> TitleOrderedGames = Games.OrderBy(t=>t.Title).ToList();
        ViewBag.TitleOrderedGames =TitleOrderedGames;
        // -6 All Games Ordered By Title & Price
        List<Game> TitlePriceOrderedGames = Games.OrderBy(t=>t.Title).OrderBy(k=>k.Price).ToList();
        ViewBag.TitlePriceOrderedGames =TitlePriceOrderedGames;
        // -7 All Games Ordered By Price & Title
        List<Game> PriceTitleOrderedGames = Games.OrderBy(i=>i.Price).OrderBy(t=>t.Title).ToList();
        ViewBag.PriceTitleOrderedGames =PriceTitleOrderedGames;
        // - 8 Favorite Game 
        Game? FavGame = Games.FirstOrDefault(j=>j.Title == "FIFA 23");
        ViewBag.FavGame = FavGame;
        // - 9 All Games Title
        List<string> AllTitles = Games.Select(y=>y.Title).ToList();
        ViewBag.AllTitles = AllTitles;
        // - 10 Price of the Most Expensive Game
        double MostExpGame = Games.Max(o=>o.Price);
        ViewBag.MostExpGame = MostExpGame;
        // - 11 Any return True or False
        bool MatchTitle  = Games.Any(a=>a.Title =="Last of Us");
        ViewBag.MatchTitle = MatchTitle;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
