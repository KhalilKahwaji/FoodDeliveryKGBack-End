using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using FoodDeliveryKG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FoodDeliveryKG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    
    {
        private readonly FoodDeliveryKGContext _context;
        
        public UsersController(FoodDeliveryKGContext context)
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
        public async Task<IActionResult> Create(User user)
        {
             await _context.users.AddAsync(new User
            {
                username = user.username,
                password = user.password,
                dateCreated = DateTime.UtcNow,
                fname = user.fname,
                lname= user.lname,
                address= user.address,
                phoneNumber = user.phoneNumber
                

            });

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}