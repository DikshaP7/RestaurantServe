using HotelServeDLL.DataContext;
using HotelServeDLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelServer_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            var getOrder = _context.tblOrders.ToList();
            return Ok(getOrder);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrders(int id)
        {
            var orders = _context.tblOrders.FirstOrDefault(x => x.OrderId == id);
            if (orders != null)
            {
                return Ok(orders);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("{id}")]
        public IActionResult AddOrders(int id, [FromBody] Orders order)
        {
            var addOrder = _context.tblOrders.FirstOrDefault(x=> x.OrderId == id);
            if(addOrder != null)
            {
                addOrder.TableId = order.TableId;
                addOrder.Items = order.Items;
                addOrder.TotalAmount = order.TotalAmount;
                addOrder.Status = order.Status;
                _context.tblOrders.Add(addOrder);
                _context.SaveChanges();
            }
            else
            {
                return NoContent();
            }
            return Ok(addOrder);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrders(int id,[FromBody] Orders orders)
        {
            var updateOrder = _context.tblOrders.FirstOrDefault(x => x.OrderId == id);
            if (updateOrder != null)
            {
                updateOrder.TableId = orders.TableId;
                updateOrder.Items = orders.Items;
                updateOrder.TotalAmount = orders.TotalAmount;
                updateOrder.Status = orders.Status;
                _context.tblOrders.Update(updateOrder);
                _context.SaveChanges();
            }
            else
            {
                return NoContent();
            }
            return Ok(updateOrder);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrders(int id)
        {
            var deleteOrder = _context.tblOrders.FirstOrDefault(x => x.OrderId == id);
            if(deleteOrder != null)
            {
                _context.tblOrders.Remove(deleteOrder);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return Ok(deleteOrder);
        }
    }
}
