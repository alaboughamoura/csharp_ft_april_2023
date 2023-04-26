#pragma warning disable CS8618


using Microsoft.EntityFrameworkCore;
namespace ManyToMany.Models;

public class MyContext : DbContext 
{ 
    public MyContext(DbContextOptions options) : base(options) { }
    // Tables
    public DbSet<Actor> Actors {get;set;}
    public DbSet<Movie> Movies {get;set;}
    public DbSet<Association> Associations {get;set;}
}
