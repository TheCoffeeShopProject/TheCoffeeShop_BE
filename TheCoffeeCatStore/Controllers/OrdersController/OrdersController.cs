using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatService.IServices;

namespace TheCoffeeCatStore.Controllers.OrdersController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices _order;

        public OrdersController(IOrderServices order)
        {
            _order = order;
        }

        // GET: api/Orders
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
          if (_order.GetOrders() == null)
          {
              return NotFound();
          }
            return _order.GetOrders().ToList();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(Guid id)
        {
            if (_order.GetOrders() == null)
            {
                return NotFound();
            }
            var order =  _order.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutOrder(Guid id, Order order)
        {
            if (_order.GetOrders() == null)
            {
                return BadRequest();
            }

            try
            {

                _order.UpdateOrder(order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_order.GetOrderById(id)==null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

    //    // POST: api/Orders
    //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //    [HttpPost]
    //    public ActionResult<Order> PostOrder(Order order)
    //    {
    //        if (_order.GetOrders() == null)
    //        {
    //            return Problem("Order is null.");
    //        }
    //        _order.AddNew(order);

    //        return CreatedAtAction("GetOrder", new { id = order.OrderID }, order);
    //    }

    //    // DELETE: api/Orders/5
    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> DeleteOrder(Guid id)
    //    {
    //        if (_order.GetOrders() == null)
    //        {
    //            return NotFound();
    //        }
    //        var order = _order.GetOrderById(id);
    //        if (order == null)
    //        {
    //            return NotFound();
    //        }

    //        _order.ChangeOrderStatus(order);

    //        return NoContent();
    //    }

      
    }
}
