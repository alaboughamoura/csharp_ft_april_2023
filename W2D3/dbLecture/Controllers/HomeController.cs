using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dbLecture.Models;

namespace dbLecture.Controllers;

public class HomeController : Controller
{
    private MyContext _context; //! 1 
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context) //! 2
    {
        _logger = logger;
        _context = context; //! 3
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost("CreateSong")]
    public IActionResult CreateSong(Song NewSong)
    {
        if(ModelState.IsValid)
        {
            // Add the new Song to DB
            // -1 Add
            _context.Add(NewSong);
            // -2 Save
            _context.SaveChanges();
            System.Console.WriteLine($"Song Title : {NewSong.Title}");
            return RedirectToAction("Index");
        }
        return View("Index");
    }
    public IActionResult Privacy()
    {
        List<Song> AllSongs = _context.Songs.OrderBy(f=> f.Title).ToList();
        return View( AllSongs);
    }
    [HttpGet("songs/{SongId}/edit")]
    public IActionResult EditSong(int SongId){
        Song? SongToEdit = _context.Songs.FirstOrDefault(p=>p.SongId == SongId);

        return View("Edit" ,SongToEdit);
    }
    [HttpPost("songs/{SongId}/update")]
    public IActionResult UpdateSong(int SongId, Song UpdatedSong)
    {
        Song? SongToUpdate = _context.Songs.FirstOrDefault(p=>p.SongId == SongId);
        if(ModelState.IsValid)
        {
            // Update
            SongToUpdate.Title = UpdatedSong.Title;
            SongToUpdate.Artist = UpdatedSong.Artist;
            SongToUpdate.Year = UpdatedSong.Year;
            SongToUpdate.Genre = UpdatedSong.Genre;
            SongToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Privacy");
        }
        return View("Edit",SongToUpdate);

    }
    [HttpPost("songs/{SongId}/delete")]
    public IActionResult DeleteSong(int SongId)
    {
        Song? SongToDelete = _context.Songs.FirstOrDefault(p=>p.SongId == SongId);
        System.Console.WriteLine($"Song To be deleted {SongToDelete?.Title} ************* {SongId} ***********************");
        _context.Songs.Remove(SongToDelete);
        _context.SaveChanges();
        return RedirectToAction("Privacy");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
