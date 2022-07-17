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
    public class RestaurantCategoryController : ControllerBase
    {

        private readonly FoodDeliveryKGContext _context;

        public RestaurantCategoryController(FoodDeliveryKGContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<RestaurantCategory>> Get()
        {
          
            return await _context.restaurantcategory.ToListAsync();
        }

/*
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByLogin(int id)
        {
            var restaurantcategory = await _context.categoryName.FindAsync(id);
            return restaurantcategory.categoryid == null ? NotFound() : Ok(restaurantcategory.categoryid);
        }*/

        /*[HttpPost]
        public async Task<IActionResult> Create(Restaurant restaurant)
        {
            await _context.restaurants.AddAsync(new Restaurant()
            {
                //userid = restaurant.userid,
                name = restaurant.name,
                username = restaurant.username,
                datecreated = DateTime.UtcNow,
                password = restaurant.password,
                //menuId = restaurant.menuId
                

            });

            await _context.SaveChangesAsync();

            return Ok();
        }*/

    }
}