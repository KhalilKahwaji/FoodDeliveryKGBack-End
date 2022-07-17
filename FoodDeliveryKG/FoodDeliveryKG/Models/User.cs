using System;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryKG
{
    public class User
    {
       [Required] public int userid { get; set; }

        public string fname { get; set; }

        public string lname { get; set; }

        public string username { get; set; }

        public DateTime dateCreated { get; set; }

        public string password { get; set; }
        
        public int phoneNumber{ get; set; }
        
        public string address { get; set; }
        
        

    }
}