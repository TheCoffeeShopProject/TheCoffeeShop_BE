using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO.Request;
using TheCoffeeCatService.IServices;
using TheCoffeeCatStore.Mapper;

namespace TheCoffeeCatStore.Controllers.OrderDetailController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailServices _oderdetail;

        public OrderDetailsController(IOrderDetailServices oderdetail)
        {
           _oderdetail = oderdetail;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public ActionResult<IEnumerable<OrderDetail>> GetOrderDetails()
        {
          if (_oderdetail.GetAllOrderDetail() == null)
          {
              return NotFound();
          }
          
            return _oderdetail.GetAllOrderDetail().ToList();
        }

        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetail>> GetOrderDetail(Guid id)
        {
          if (_oderdetail.GetAllOrderDetail() == null)
          {
              return NotFound();
          }
            var orderDetail = _oderdetail.GetOrderDetail(id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return orderDetail;
        }

        //// PUT: api/OrderDetails/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOrderDetail(Guid id, OrderDetail orderDetail)
        //{
        //    if (id != orderDetail.OrderDeatailID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(orderDetail).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderDetailExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}
        [HttpPost]
        public ActionResult<OrderDetail> AddNewOrderDetail([FromForm] OrderDetailCreateDTO orderDetailDTO)
        {  
        
            var config = new MapperConfiguration(
              cfg => cfg.AddProfile(new OrderDetailProfile())
          );
            // create mapper
            var mapper = config.CreateMapper();


            var orderdetail = mapper.Map<OrderDetail>(orderDetailDTO);
         
            _oderdetail.AddNew(orderdetail);


            return Ok("Create Successfully");
        }

        // DELETE: api/OrderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(Guid id)
        {
            if (_oderdetail.GetAllOrderDetail() == null)
            {
                return NotFound();
            }
            var orderDetail =  _oderdetail.GetOrderDetail(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            _oderdetail.Delete(orderDetail);
       

            return NoContent();
        }

        
    }
}
