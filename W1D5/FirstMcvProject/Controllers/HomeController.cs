using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstMcvProject.Models;

namespace FirstMcvProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public static List<Pet> AllPets = new List<Pet>();
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet("success")]
    public IActionResult Success()
    {
        return View();
    }
    [HttpPost("create")]
    public IActionResult Create(Pet NewPet)
    {
       
        if(ModelState.IsValid)
        {
             System.Console.WriteLine($"Name : {NewPet.Name}\nAge : {NewPet.Age}\nIsFriendly : {NewPet.IsFriendly}\nColor : {NewPet.Color}");
            AllPets.Add(NewPet);
            return View("Success", AllPets);
        }
        return View("Index");
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
