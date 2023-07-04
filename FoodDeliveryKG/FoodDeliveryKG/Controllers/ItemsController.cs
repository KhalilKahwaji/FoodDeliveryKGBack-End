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
          
            return await _context.item.ToListAsync();
        }
        
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByLogin(int id)
        {
            if (id != null)
            {
                var items = await _context.item.FindAsync(id);
                return items.itemid == null ? NotFound() : Ok(items);
            }

            return NotFound();

        }
        
        [HttpGet("GetMenu/{resid}")]
        public async Task<IActionResult> GetMenu(int resid)
        {
            Array arr = (
                from items in _context.item
                where items.restaurantid == resid
                select items
            ).ToArray();

           return Ok(arr);

        }
        
        [HttpGet("GetMenuFiltered/{resid}/{itemCat}")]
        public async Task<IActionResult> GetMenuFiltered(int resid, int itemCat)
        {
            Array arr = (
                from items in _context.item
                where (items.restaurantid == resid) && (items.categoryid==itemCat)
                select items
            ).ToArray();
            return Ok(arr);

        }

        
        [HttpPost]
        public async Task<IActionResult> Create(Items item)
        {
            await _context.item.AddAsync(new Items
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
