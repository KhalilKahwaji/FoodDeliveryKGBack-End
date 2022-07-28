using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryKG.Models;

public class FullOrderDetails
{
    [Required] public int orderdetailid { get; set; }
    
    [Required] public int orderid { get; set; }
    
    public int statusid { get; set; }
    
    public int userid { get; set; }
    
    public int restaurantid { get; set; }
    
    public DateTime dateoforder { get; set; }
    
    public int itemid { get; set; }


    public int quantity { get; set; }
    
    public int price { get; set; }
    
    public string itemname { get; set; }
    
   
        
    public string customerFullName { get; set; }

    public FullOrderDetails(int orderdetailid, int orderid, int statusid, int userid, int restaurantid, DateTime dateoforder, int itemid, int quantity, int price, string itemname, string customerFullName)
    {
        this.orderdetailid = orderdetailid;
        this.orderid = orderid;
        this.statusid = statusid;
        this.userid = userid;
        this.restaurantid = restaurantid;
        this.dateoforder = dateoforder;
        this.itemid = itemid;
        this.quantity = quantity;
        this.price = price;
        this.itemname = itemname;
        this.customerFullName = customerFullName;
    }

    public FullOrderDetails()
    {
    }
    
    public FullOrderDetails(int orderdetailid, int orderid, int statusid, int userid, int restaurantid, DateTime dateoforder, int itemid, int quantity, int price)
    {
        this.orderdetailid = orderdetailid;
        this.orderid = orderid;
        this.statusid = statusid;
        this.userid = userid;
        this.restaurantid = restaurantid;
        this.dateoforder = dateoforder;
        this.itemid = itemid;
        this.quantity = quantity;
        this.price = price;
        this.itemname = "not set";
        this.customerFullName = "not set";
    }

}