using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CraftsShop.Models;
using Microsoft.AspNetCore.Identity; //- Hashing Password
using Microsoft.EntityFrameworkCore;

namespace CraftsShop.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    // ----------------------------------------User Controller---------------------------------------------------

    // GET : FORM
    public IActionResult Index()
    {
        return View();
    }

    // POST : REGISTER
    [HttpPost("/users/create")]
    public IActionResult CreateUser(User newUser)
    {
        if(ModelState.IsValid)
        {
            if(_context.Users.Any(u=> u.Email == newUser.Email))
            {
                ModelState.AddModelError("Email","Email Already taken , hope by you !!!");
                return View("Index");
            }
            // Hash Password
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            // Add User ID in Session
            HttpContext.Session.SetInt32("userId",newUser.UserId);
            return RedirectToAction("Dashboard");
        }
        return View("Index");
    }
    // GET : USER DASHBOARD
    public IActionResult Dashboard()
    {
        if(HttpContext.Session.GetInt32("userId")!= null)
        {
            int? userId = (int)HttpContext.Session.GetInt32("userId");
            User? user = _context.Users.FirstOrDefault(u=>u.UserId == userId);
            int CraftsBought = _context.Orders.Where(o=>o.UserId == userId).Count();
            ViewBag.CraftsBought = CraftsBought;
            List<Order> TotalSold = _context.Orders.Include(a=> a.Craft).Where(c=>c.UserId == userId).ToList();
            ViewBag.TotalSold = TotalSold;
            return View(user);
        }
        return RedirectToAction("Index");
    }
    // POST : LOGIN
    [HttpPost("/users/login")]
    public IActionResult Login (LoginUser loginUser)
    {
        if(ModelState.IsValid)
        {
            // Login
            // search for a user that match the login email
            var UserFromDB = _context.Users.FirstOrDefault(u=> u.Email == loginUser.LoginEmail);
            if(UserFromDB == null)
            {
                ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                return View("Index");
            }
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            //  verify Password 
            var  result = hasher.VerifyHashedPassword(loginUser,hashedPassword: UserFromDB.Password, loginUser.LoginPassword);
            if(result == 0)
            {
                ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                return View("Index");
            }
            HttpContext.Session.SetInt32("userId", UserFromDB.UserId);
            return RedirectToAction("Dashboard");
        }
        // 
        return View("Index");
    }

    public IActionResult OrderHistory()
    {
        if(HttpContext.Session.GetInt32("userId")!= null)
        {
            int? userId = (int)HttpContext.Session.GetInt32("userId");
            ViewBag.Selling = _context.Orders.Include(navigationPropertyPath: c=>c.Craft).ThenInclude(o=> o.Creator).Where(t=> t.Craft.UserId == userId).ToList();
            // System.Console.WriteLine(ViewBag.Selling[0]);
            return View();
        }
        return RedirectToAction("Index");
    }

    // GET : LOGOUT
    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
    //!                                  END User Controller                                                

    // ---------------------------------Craft Controller ---------------------------------------------------
    // GET : New Craft
    [HttpGet("/crafts/new")]
    public IActionResult NewCraft()
    {
        if(HttpContext.Session.GetInt32("userId")!= null)
        {
            return View();
        }
        return RedirectToAction("Index");
    }
    // POST : Add Craft
    [HttpPost("/crafts/create")]
    public IActionResult CreateCraft(Craft newCraft)
    {
        if(ModelState.IsValid)
        {
            newCraft.UserId = (int)HttpContext.Session.GetInt32("userId");
            _context.Add(newCraft);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        return View("NewCraft");
    }
    // GET : All Crafts
    public IActionResult Crafts()
    {
        if(HttpContext.Session.GetInt32("userId")!= null)
        {
            List<Craft> AllCrafts = _context.Crafts.Include(c=>c.Creator).ToList();
            return View(AllCrafts);
        }
        return RedirectToAction("Index");
    }
    // GET : One Craft
    [HttpGet("/crafts/{CraftId}")]
    public IActionResult OneCraft(int CraftId)
    {
        Craft? OneCraft = _context.Crafts.Include(c=>c.Creator).FirstOrDefault(c=>c.CraftId == CraftId);
        ViewBag.OneCraft = OneCraft;
        return View();
    }
    // POST : Delete One Craft
    [HttpPost("/crafts/{CraftId}/destroy")]
    public IActionResult DestroyCraft(int CraftId)
    {
        Craft? CraftToDestroy = _context.Crafts.FirstOrDefault(c=>c.CraftId == CraftId);
        _context.Remove(CraftToDestroy);
        _context.SaveChanges();
        return RedirectToAction("Crafts");
    }
    // !                                   End Craft Controller                                             

    // ---------------------------------Order Controller ---------------------------------------------------
    [HttpPost("/orders/create")]
    public IActionResult CreateOrder(Order newOrder)
    {
        System.Console.WriteLine($"CraftId = {newOrder.CraftId} ---- Quantity = {newOrder.QuantityOrdered}");
        newOrder.UserId = (int)HttpContext.Session.GetInt32("userId");
        _context.Add(newOrder);
        Craft? craftToUpdate = _context.Crafts.FirstOrDefault(c=>c.CraftId == newOrder.CraftId);
        craftToUpdate.Quantity -= newOrder.QuantityOrdered;
        craftToUpdate.UpdatedAt = DateTime.Now;
        _context.SaveChanges();
        return RedirectToAction("Crafts");
    }
    // !                                   End Order Controller                                             
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
