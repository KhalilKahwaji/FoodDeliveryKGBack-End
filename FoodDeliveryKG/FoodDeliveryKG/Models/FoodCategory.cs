using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryKG.Models;

public class FoodCategory
{
    [Required] public int categoryid { get; set; }
    public string categoryname { get; set; }
}