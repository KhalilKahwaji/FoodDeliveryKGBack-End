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

    public class OrderDetailController : ControllerBase
    {
        private readonly FoodDeliveryKGContext _context;
        
        public OrderDetailController(FoodDeliveryKGContext context)
        {
            _context = context;
        }
        
        
        [HttpGet]
        public async Task<IEnumerable<OrderDetail>> Get()
        {
          
            return await _context.orderdetail.ToListAsync();
        }
        
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByLogin(int id)
        {
            if (id != null)
            {
                var orderdetail = await _context.orderdetail.FindAsync(id);
                /*FullOrder fo = new FullOrder();
                var tmp = await _context.orders.FindAsync(orderdetail.orderid);
                var tmp2 = await _context.users.FindAsync(tmp.userid);
                fo.user = tmp2.fname + "  " + tmp2.lname;
                fo.restaurant = " ";
                fo.foodcategory = " ";*/
                
                return orderdetail.orderdetailid == null ? NotFound() : Ok(orderdetail);
            }

            return NotFound();

        }
        
      
        //   
        // [HttpPost]
        // public async Task<IActionResult> Create(OrderDetail orderdetail)
        // {
        //     await _context.orderdetail.AddAsync(new OrderDetail
        //     {
        //
        //         orderid = orderdetail.orderid,
        //         itemid = orderdetail.itemid,
        //         quantity = orderdetail.quantity,
        //         price = orderdetail.price
        //
        //     });
        //
        //     await _context.SaveChangesAsync();
        //
        //     return Ok();
        // }

        
        [HttpPost]
        public async Task<IActionResult> CreateFullOrder(FullOrderDetails orderdetail)
        {
            int myOrderID=-1;
            await _context.orders.AddAsync(new Orders
            {
               
                statusid = 1,
                userid = orderdetail.userid,
                restaurantid = orderdetail.restaurantid,
                dateoforder = DateTime.UtcNow

            });

            _context.SaveChanges();
            foreach (Orders o in _context.orders)
            {
                if (myOrderID < o.orderid)
                {
                    myOrderID = o.orderid;
                }
            }
            await _context.orderdetail.AddAsync(new OrderDetail
            {

                
                orderid = myOrderID,
                itemid = orderdetail.itemid,
                quantity = orderdetail.quantity,
                price = orderdetail.price

            });

            await _context.SaveChangesAsync();

            return Ok();
        }
    }    
    
}
