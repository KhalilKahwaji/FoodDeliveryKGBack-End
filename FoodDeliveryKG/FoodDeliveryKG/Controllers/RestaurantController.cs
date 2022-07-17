using System;
using System.Collections.Generic;
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
        public async Task<IEnumerable<User>> Get()
        {
            return await _context.users.ToListAsync();
        }


        [HttpGet("{username}/{password}")]
        public async Task<IActionResult> GetByLogin(string username, string password)
        {
            var user = await _context.users.FindAsync(username, password);
            return user.userid == null ? NotFound() : Ok(user.userid);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Restaurant restaurant)
        {
            await _context.restaurants.AddAsync(new Restaurant()
            {
                //userid = restaurant.userid,
                name = restaurant.name,
                username = restaurant.username,
                dateCreated = DateTime.UtcNow,
                password = restaurant.password,
                //menuId = restaurant.menuId
                

            });

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}