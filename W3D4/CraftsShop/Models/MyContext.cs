#pragma warning disable CS8618


using Microsoft.EntityFrameworkCore;
namespace CraftsShop.Models;

public class MyContext : DbContext 
{ 
    public MyContext(DbContextOptions options) : base(options) { }
    // ! Don't Forget To Add All Tables  
    public DbSet<User> Users { get; set; } 
    public DbSet<Craft> Crafts { get; set; } 
    public DbSet<Order> Orders { get; set; } 
}