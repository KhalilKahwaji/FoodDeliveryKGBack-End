using System;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryKG
{
    public class Restaurant
    {
        [Required] public int id { get; set; }

        public string name { get; set; }

        public string username { get; set; }

        
        public DateTime dateCreated { get; set; }

        public string password { get; set; }
        
        //public int menuId { get; set; }//????????//

        public string address { get; set; }

        public int phoneNumber;

    }
}