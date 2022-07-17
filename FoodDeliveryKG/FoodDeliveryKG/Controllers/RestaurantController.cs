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
        public async Task<IEnumerable<Restaurant>> Get()
        {
            return await _context.restaurants.ToListAsync();
        }


        [HttpGet("{username}/{password}")]
        public async Task<IActionResult> GetByLogin(string username, string password)
        {
            var restaurant = await _context.restaurants.FindAsync(username, password);
            return restaurant.restaurantid == null ? NotFound() : Ok(restaurant);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByLogin(int id)
        {
            var restaurant = await _context.restaurants.FindAsync(id);
            return restaurant.restaurantid == null ? NotFound() : Ok(restaurant);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Create(Restaurant restaurant)
        {
            await _context.restaurants.AddAsync(new Restaurant()
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

            return Ok();
        }
    }
}