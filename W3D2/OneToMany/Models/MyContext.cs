#pragma warning disable CS8618


using Microsoft.EntityFrameworkCore;
namespace OneToMany.Models;

public class MyContext : DbContext 
{ 
    public MyContext(DbContextOptions options) : base(options) { }
    public DbSet<Owner> Owners { get; set; } 
    public DbSet<Car> Cars { get; set; } 
}
