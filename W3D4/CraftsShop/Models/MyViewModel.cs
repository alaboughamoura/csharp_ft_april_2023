#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CraftsShop.Models;


public class MyViewModel
{
    public User User { get; set; }
    public List<Craft> AllCrafts { get; set; }
    public List<Order> AllOrders { get; set; }
}