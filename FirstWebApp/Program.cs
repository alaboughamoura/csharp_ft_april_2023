var builder = WebApplication.CreateBuilder(args);
// 1
// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();
// 2 
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
// 3
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
