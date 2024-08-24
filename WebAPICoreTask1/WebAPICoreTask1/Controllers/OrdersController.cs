using Microsoft.AspNetCore.Mvc;
using WebAPICoreTask1.Models;

namespace WebAPICoreTask1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly MyDbContext _db;

        public OrdersController(MyDbContext db)
        {
            _db = db;
        }



        [HttpGet("GetAllOrders")]

        public ActionResult GetAllOrders()
        {
            var orders = _db.Orders;

            if (orders == null)
            {

                return NotFound("No Orders Found");
            }

            return Ok(orders);


        }


        [HttpGet("GetOrderByID/{id}")]

        public ActionResult GetOneOrder(int id)
        {

            if (id <= 0)
            {
                return BadRequest("Plz enter a number greater than 0");
            }


            var Order = _db.Orders.FirstOrDefault(o => o.OrderId == id);


            if (Order == null)
            {
                return NotFound($"No order found with ID {id}");
            }


            return Ok(Order);

        }

        [HttpGet("GetOrderByDate/{date}")]
        public IActionResult GetOrderByDate(DateTime date)
        {
            var order = _db.Orders.Where(o => o.OrderDate.HasValue && o.OrderDate.Value.Date == date.Date).ToList();

            if (order == null || order.Count == 0)
            {
                return NotFound($"No orders found on {date.Date.ToShortDateString()}");
            }

            return Ok(order);
        }


        [HttpDelete("DeleteOrderByID")]

        public ActionResult DeleteOrder(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Plz enter an id greater than 0");

            }

            var order = _db.Orders.FirstOrDefault(o => o.OrderId == id);

            if (order == null)
            {

                return NotFound($"No order with Id {id} found");

            }

            _db.Orders.Remove(order);

            _db.SaveChanges();

            return Ok("Order Deleted");


        }

    }
}
