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
            return await _context.user.ToListAsync();
            
        }


        [HttpGet("{username}/{password}")]
        public async Task<IActionResult> GetByLogin(string username, string password)
        {
            Object userToAuth = (
                from users in _context.user
                where users.username == username
                where users.password == password
                select users
            );



            return Ok(userToAuth);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            string newusername="";
           
            bool exists = false;
            bool samephone = false;
            
            
            foreach (User u in _context.user)
            {
                if (u.username == user.username)
                {
                    exists = true;
                   
                }

                if (u.phoneNumber == user.phoneNumber)
                {
                    samephone = true;
                }
            }

            if (samephone)
            {
                return NotFound("Phone number already registered to an account. Please use a different one.");

            }
           
            bool passedbyhere = false;
            
            if (exists)
            {
                for (int i = 100; i < 10000; i++)
                {

                    Random rnd = new Random();
                    int num = rnd.Next(1000);


                    newusername = user.username + num.ToString();
                    
                    foreach (User u in _context.user)
                    {
                     
                        if (u.username == newusername)
                        {
                            passedbyhere = true;
                            
                            break;
                        }
                    }

                    if (!passedbyhere)
                    {
                        break;
                    }
                }
                return NotFound("Username already exists! Try "+ newusername);

            }
            
                
             await _context.user.AddAsync(new User
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
           
            return Ok(user);
            
        }
        
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByLogin(int id)
        {
            if (id != null)
            {
                var user = _context.user.Find(id);
                
                return user.userid == null ? NotFound() : Ok(user);
            }

            return NotFound();

        }
        
        /*
        [HttpGet("LOG{uname}")]
        public async Task<IActionResult> Get(string uname)
        {
            foreach(User u in _context.users)
            {
                if (u.username == uname)
                {
                    return Ok(u.password);
                }
            }

            

            return NotFound();

        }*/
    }
}