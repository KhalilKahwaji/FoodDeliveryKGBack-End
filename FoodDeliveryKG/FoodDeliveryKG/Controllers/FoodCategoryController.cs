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
    public class FoodCategoryController
    {
        private readonly FoodDeliveryKGContext _context;

        public FoodCategoryController(FoodDeliveryKGContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<FoodCategory>> Get()
        {
          
            return await _context.foodcategory.ToListAsync();
        }
    }    
}