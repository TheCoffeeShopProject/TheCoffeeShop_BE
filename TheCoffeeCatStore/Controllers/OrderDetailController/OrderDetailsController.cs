using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatService.IServices;

namespace TheCoffeeCatStore.Controllers.OrderDetailController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailServices _orderdetail;

        public OrderDetailsController(IOrderDetailServices orderdetail)
        {
            _orderdetail = orderdetail;
        }


    

        // POST: api/OrderDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderDetail>> PostOrderDetail(OrderDetail orderDetail)
        {
            //if (_context.OrderDetails == null)
            //{
            //    return Problem("Entity set 'TheCoffeeStoreDBContext.OrderDetails'  is null.");
            //}
            _orderdetail.AddNew(orderDetail);

           

            return CreatedAtAction("GetOrderDetail", new { id = orderDetail.OrderDeatailID }, orderDetail);
        }

        //// DELETE: api/OrderDetails/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOrderDetail(Guid id)
        //{
        //    if (_context.OrderDetails == null)
        //    {
        //        return NotFound();
        //    }
        //    var orderDetail = await _context.OrderDetails.FindAsync(id);
        //    if (orderDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.OrderDetails.Remove(orderDetail);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}


    }
}
