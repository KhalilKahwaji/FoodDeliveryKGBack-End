using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using FoodDeliveryKG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FoodDeliveryKG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    
    {
        private readonly FoodDeliveryKGContext _context;

        public RestaurantController(FoodDeliveryKGContext context)
        {
            _context = context;
        }
        
        
        [HttpGet]
        public async Task<IEnumerable<Restaurant>> Get()
        {
            return await _context.restaurant.ToListAsync();
        }


        // [HttpGet("{username}/{password}")]
        // public async Task<IActionResult> GetByLogin(string username, string password)
        // {
        //     var restaurant = await _context.restaurants.FindAsync(username, password);
        //     return restaurant.restaurantid == null ? NotFound() : Ok(restaurant);
        // }

        [HttpGet("{username}/{password}")]
        public async Task<IActionResult> GetByLogin(string username, string password)
        {
            Object userToAuth = (
                from restaurants in _context.restaurant
                where restaurants.username == username
                where restaurants.password == password
                select restaurants
            );

            return Ok(userToAuth);
        }
        
        
        
        [HttpGet("logindata/{username}")]
        public async Task<IActionResult> Get(string username)
        {
            Restaurant res = new Restaurant();
            string[] usernames;
            //get the restaurant
            foreach (Restaurant r in _context.restaurant)
            {
                if (r.username == username)
                {
                    res = r;
                    break;
                }
            }

            List<Object> usersStrings= new List<Object>();
            int ind = 0;
            Array userToAuth = (
                from orders in _context.order
                where orders.restaurantid == res.restaurantid
                select orders.userid
            ).ToArray();
            
            Array.Sort(userToAuth);
            int curid = -1;
            
            
            for (int i = 0; i < userToAuth.Length; i++)
            {
                if ((int)userToAuth.GetValue(i) == curid)
                {
                    continue;
                }
                else
                {
                    curid = (int)userToAuth.GetValue(i) ;
                     
                    /*Object tmp = (
                        from users in _context.users
                        where users.userid == curid
                        select users
                    );*/
                    foreach (User u in _context.user)
                    {
                        if (u.userid == curid)
                        {
                            usersStrings.Add(u);
                            ind++;
                            break;
                        }
                    }
                    
                }
            }


            return usersStrings.Count == 0
                ? Ok("No customers yet.")
                : Ok(usersStrings); //restaurant.restaurantid == null ? NotFound() : Ok(restaurant);
        }
        
        
        [HttpGet("RestaurantItems/{id}")]
        public async Task<IActionResult> Getitems(int id)
        {
            Array itemsarr = (
                from items in _context.item
                where items.restaurantid == id
                select items
            ).ToArray();
            
            
            return itemsarr.Length == 0
                ? Ok("No items yet.")
                : Ok(itemsarr);
        }
        
        [HttpGet("RestaurantCategory/{cat}")]
        public async Task<IActionResult> GetRestaurantWithCategory(string cat)
        {
            int catId=0;
            foreach (RestaurantCategory rc in _context.restaurantcategory)
            {
                if (rc.categoryname.Equals(cat))
                {
                    catId = rc.categoryid;
                    break;
                }
            }
            Array restArr = (
                from restaurants in _context.restaurant
                where restaurants.categoryid == catId
                select restaurants
            ).ToArray();


            return Ok(restArr);
        }

        
        
        [HttpGet("SearchRestaurants/{str}")]
        public async Task<IActionResult> SearchRestaurants(string str)
        {
            int catId=0;
            List<Restaurant> rests = new List<Restaurant>();
            foreach (Restaurant r in _context.restaurant)
            {
                if (r.name.ToLower().Contains(str.ToLower()))
                {
                   rests.Add(r);
                }
            }



            return Ok(rests);
        }

        
        [HttpGet("DeleteItem/{id}")]
        public async Task<IActionResult> DelItem(int id)
        {


            var itt = (
                from items in _context.item
                where items.itemid == id
                select items
            );
                    _context.item.RemoveRange(itt);
                    _context.SaveChanges();

            return Ok("item deleted.");
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByLogin(int id)
        {
            var restaurant = await _context.restaurant.FindAsync(id);
            return restaurant.restaurantid == null ? NotFound() : Ok(restaurant);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(Restaurant restaurant)
        {
            
            
            bool exists = false;
            bool samephone = false;
            
            
            foreach (Restaurant u in _context.restaurant)
            {
                if (u.username == restaurant.username)
                {
                    exists = true;
                   
                }

                if (u.phonenumber == restaurant.phonenumber)
                {
                    samephone = true;
                }
            }
            if (samephone)
            {
                return NotFound("Phone number already registered to an account. Please use a different one.");

            }

            if (exists)
            {
                return NotFound("Username already exists! Try another one.");

            }

            await _context.restaurant.AddAsync(new Restaurant()
            {
                name = restaurant.name,
                username = restaurant.username,
                datecreated = DateTime.UtcNow,
                password = restaurant.password,
                address= restaurant.address,
                phonenumber = restaurant.phonenumber,
                categoryid = restaurant.categoryid


            });

            await _context.SaveChangesAsync();

            return Ok(restaurant);
        }
    }
}