using System;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryKG
{
    public class Restaurant
    {
        [Required] public int restaurantid { get; set; }

        public string name { get; set; }

        public string username { get; set; }
        
        public DateTime datecreated { get; set; }

        public string password { get; set; }

        public string address { get; set; }

        public int phonenumber { get; set; }

        public int categoryid { get; set; }

    }
}