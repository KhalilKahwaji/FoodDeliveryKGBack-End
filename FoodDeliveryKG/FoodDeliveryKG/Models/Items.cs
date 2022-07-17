using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryKG.Models;

public class Items
{
    [Required]public int itemid { get; set; }
    
    public string name { get; set; }
    
    public int price{ get; set; }
    
    public string image { get; set; }
    
    public int restaurantid{ get; set; }
    
    public int categoryid{ get; set; }
}