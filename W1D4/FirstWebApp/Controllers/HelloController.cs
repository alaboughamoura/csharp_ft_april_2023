using Microsoft.AspNetCore.Mvc;
namespace FirstWebApp.Controllers; // Include the controller in the project 
public class HelloController : Controller
{
    // Routes
    [HttpGet] // Type of the request
    [Route("")] // associated route (/)
    public ViewResult Index() // ViewResult : Type of the return will be a View (cshtml file)
    {
        return View("Index");
    }
    [HttpGet("second/{name}")]
    public string Second(string name)
    {
        return $"Hi {name}😄";
    }
    [HttpGet("third/{number}")]
    public string Third(int number)
    {
        return $"FavNumber is {number} 😄";
    }
    [HttpGet("display")]
    public ViewResult Display()
    {
        ViewBag.Username = "Alex";
        ViewBag.FavNumber = 5;
        return View();
    }
    [HttpPost("process")]
    public IActionResult Process(string Username, int FavNumber)
    {
        System.Console.WriteLine($"Username  : {Username}\n Favorite Number : {FavNumber}");
        if(Username == "" || FavNumber == 0){
            ViewBag.Error = "Wrong Information";
            return RedirectToAction(actionName: "Index");
        }
        ViewBag.Username = Username;
        ViewBag.FavNumber = FavNumber;
        return View("Display");
    }
}
