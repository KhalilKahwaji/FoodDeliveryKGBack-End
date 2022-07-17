using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryKG.Models;

public class OrderStatus
{
    [Required] public int statusid { get; set; }
    public string statusname { get; set; }
}