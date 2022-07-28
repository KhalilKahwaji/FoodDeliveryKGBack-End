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
        [HttpGet("changeStatus/{id}/{newStatus}")]
        public async Task<IActionResult> ChangeOrderStatus(int id, int newStatus)
        {
            Orders tmp = new Orders();
            /*var orrr = (
                from orders in _context.orders
                where orders.orderid == id
                select orders
            );*/
            
            Orders tst= (from p in _context.orders
                    where p.orderid == id select p).SingleOrDefault();
            tst.statusid = newStatus;
            _context.SaveChanges();
            // tmp = (Orders) orrr;
                /*if(o.orderid==id)
                {
                   
                    tmp = o;
                    tmp.statusid = newStatus;
                    _context.orders.RemoveRange(o);
                    _context.SaveChanges();
                    break;
                }*/
            
           // await _context.orders.AddAsync(tmp);
            return Ok(tst);

        }
        
        [HttpGet("OrdersToRestaurant/{id}")]
        public async Task<IActionResult> GetOrdersToRest(int id)
        {
            Array ordersToRes = (
                from orders in _context.orders
                where orders.restaurantid == id
                select orders
            ).ToArray<Orders>();

            List<FullOrderDetails> fullOrders = new List<FullOrderDetails>();
            FullOrderDetails tst= new FullOrderDetails();
            for (int i = 0; i < ordersToRes.Length; i++)
            {
                Orders tmpOrder = (Orders)ordersToRes.GetValue(i);

                foreach (OrderDetail od in _context.orderdetail)
                {   
                    if (tmpOrder.orderid == od.orderid)
                    {
                        //FullOrderDetails(int orderdetailid, int orderid, int statusid, int userid, int restaurantid, DateTime dateoforder, int itemid, int quantity, int price)
                           // Console.WriteLine("OK>>>");
                           // Items it =  _context.items.Find(od.itemid);
                           // User us = _context.users.Find(tmpOrder.userid);
                           
                           
                           FullOrderDetails tmpFOD = new FullOrderDetails(od.orderdetailid, tmpOrder.orderid,
                               tmpOrder.statusid, tmpOrder.userid, tmpOrder.restaurantid, tmpOrder.dateoforder,
                               od.itemid, od.quantity, od.price);//it.name, (us.fname+" "+us.lname));
                        fullOrders.Add(tmpFOD);
                        tst = tmpFOD;
                        break;
                    }

                }

            }
            
            return Ok( fullOrders);

        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Orders order)
        {
            await _context.orders.AddAsync(new Orders
            {
                //id automatically
                statusid = 1,
                userid = order.userid,
                restaurantid = order.restaurantid,
                dateoforder = DateTime.UtcNow

            });

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}