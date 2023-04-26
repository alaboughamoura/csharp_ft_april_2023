using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ManyToMany.Models;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger,MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    // --------------------------------------------------------------
    // GET 👀
    public IActionResult Index()
    {
        List<Actor> AllActors = _context.Actors.ToList();
        ViewBag.AllActors = AllActors;
        return View();
    }
    // POST 📤
    [HttpPost(template: "/actors/create")]
    public IActionResult CreateActor(Actor newActor)
    {
        if(ModelState.IsValid)
        {
            // Add
            _context.Add(newActor);
            // Save
            _context.SaveChanges();
            // -Redirect
            return RedirectToAction("Index");
        }
        return View("Index");
    }
    // ----------------------------------------------------------------
    // GET 👀
    public IActionResult Privacy()
    {
        List<Movie> AllMovies = _context.Movies.ToList();
        ViewBag.AllMovies = AllMovies;
        return View();
    }
    //  POST 📤
    [HttpPost("/movies/create")]
    public IActionResult CreateMovie(Movie newMovie)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newMovie);
            _context.SaveChanges();
            return RedirectToAction("Privacy");
        }
        return View("Privacy");
    }
    // ----------------------------------------------------------------
    //  GET 👀
    public IActionResult Association()
    {
        List<Movie> AllMovies = _context.Movies.Include(m=>m.MyActors).ThenInclude(asc=>asc.Actor).ToList();
        ViewBag.AllMovies = AllMovies;
        List<Actor> AllActors = _context.Actors.Include(a=>a.MyMovies).ThenInclude(asc=>asc.Movie).ToList();
        ViewBag.AllActors = AllActors;
        // List<Actor> AllAssociations = _context.Associations.ToList();
        // ViewBag.AllAssociations = AllAssociations;
        return View();
    }
    // POST 📤
    [HttpPost("/associations/create")]
    public IActionResult AddAssociation(Association newAssociation)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newAssociation);
            _context.SaveChanges();
            return RedirectToAction("Association");
        }
        return View("Association");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
