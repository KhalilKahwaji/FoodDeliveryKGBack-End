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

    public class OrdersController : ControllerBase
    {
        private readonly FoodDeliveryKGContext _context;

        public OrdersController(FoodDeliveryKGContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Orders>> Get()
        {
          
            return await _context.orders.ToListAsync();
        }
        
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByLogin(int id)
        {
            if (id != null)
            {
                var orders = await _context.orders.FindAsync(id);
                return orders.orderid == null ? NotFound() : Ok(orders);
            }

            return NotFound();

        }
        
        
        [HttpPost]
        public async Task<IActionResult> Create(Orders order)
        {
            await _context.orders.AddAsync(new Orders
            {

                statusid = order.statusid,
                userid = order.userid,
                restaurantid = order.restaurantid,
                dateoforder = DateTime.UtcNow

            });

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}