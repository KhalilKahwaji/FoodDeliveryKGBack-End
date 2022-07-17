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
    
    public class OrderStatusController
    {
        private readonly FoodDeliveryKGContext _context;

        public OrderStatusController(FoodDeliveryKGContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<OrderStatus>> Get()
        {
          
            return await _context.orderstatus.ToListAsync();
        }
    }    
}
