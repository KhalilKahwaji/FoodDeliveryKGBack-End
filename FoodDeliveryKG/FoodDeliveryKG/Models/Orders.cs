using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryKG.Models;

public class Orders
{
    [Required] public int orderid { get; set; }
    
    public int statusid { get; set; }
    
    public int userid { get; set; }
    
    public int restaurantid { get; set; }
    
    public DateTime dateoforder { get; set; }
    
}
