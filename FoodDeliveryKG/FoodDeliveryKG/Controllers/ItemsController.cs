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

    public class ItemsController : ControllerBase
    {
        private readonly FoodDeliveryKGContext _context;

        public ItemsController(FoodDeliveryKGContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<Items>> Get()
        {
          
            return await _context.items.ToListAsync();
        }
        
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByLogin(int id)
        {
            if (id != null)
            {
                var items = await _context.items.FindAsync(id);
                return items.itemid == null ? NotFound() : Ok(items);
            }

            return NotFound();

        }
        
        
        [HttpPost]
        public async Task<IActionResult> Create(Items item)
        {
            await _context.items.AddAsync(new Items
            {

                name = item.name,
                price = item.price,
                image = item.image,
                restaurantid = item.restaurantid,
                categoryid = item.categoryid

            });

            await _context.SaveChangesAsync();

            return Ok();
        }
    }    
}
