using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using sessionLecture.Models;
// -----------Config To Use Session (3)                     
using Microsoft.AspNetCore.Http;
// -                                                        

namespace sessionLecture.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // HttpContext.Session.SetString("Username","John");
        // HttpContext.Session.SetInt32("FavNumber",40);
        string Name = "John"; //SET
        // System.Console.WriteLine(Name); //GET
        return View();
    }

    public IActionResult Privacy()
    {
        if(HttpContext.Session.GetString("Username")==null)
        {
            return RedirectToAction("Index");
        }
        // string? Username = HttpContext.Session.GetString("Username");
        //! Strings are nullable but Int cannot be null
        // int? FavNumber  = HttpContext.Session.GetInt32("FavNumber");
        return View();
    }
    [HttpGet("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [HttpPost("create")]
    public IActionResult Create(string Username, int FavNumber)
    {
        System.Console.WriteLine($"Username : {Username}\nFavorite Number : {FavNumber}");
        System.Console.WriteLine($"Old FavNumber in session {HttpContext.Session.GetInt32("FavNumber")}");
        HttpContext.Session.SetString("Username",Username);
        int? OldSession = HttpContext.Session.GetInt32("FavNumber");
        // HttpContext.Session.SetInt32("FavNumber",FavNumber+(int)OldSession);
        HttpContext.Session.SetInt32("FavNumber",FavNumber);
        return RedirectToAction("Privacy");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
