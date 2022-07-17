using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryKG.Models;

public class OrderDetail
{
    [Required] public int orderdetailid { get; set; }
    
    public int orderid { get; set; }
    
    public int itemid { get; set; }
    
    public int quantity { get; set; }
    
    public int price { get; set; }
}