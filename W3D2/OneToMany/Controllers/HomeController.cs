using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OneToMany.Models;
using Microsoft.EntityFrameworkCore;

namespace OneToMany.Controllers;

public class HomeController : Controller
{
     private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        List<Owner> AllOwners = _context.Owners.Include(owner=>owner.CarsOwned).ToList();
        ViewBag.AllOwners = AllOwners;
        return View();
    }
    [HttpGet("/cars/new")]
    public IActionResult Cars()
    {
        List<Owner> AllOwners = _context.Owners.ToList();
        ViewBag.AllOwners = AllOwners;
        List<Car> AllCars = _context.Cars.Include(car=> car.Owner).ToList();
        ViewBag.AllCars = AllCars;
        return View();
    }
    [HttpPost("/owners/create")]
    public IActionResult CreateOwner(Owner newOwner)
    {
        if(ModelState.IsValid)
        {
            // Add
            _context.Add(newOwner);
            // Save
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("Index");
    }
    [HttpPost("/cars/create")]
    public IActionResult CreateCar(Car newCar)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newCar);
            _context.SaveChanges();
            return RedirectToAction("Cars");
        }
        return View("Cars");
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
