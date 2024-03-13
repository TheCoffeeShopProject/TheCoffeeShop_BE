using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO.Request;
using TheCoffeeCatService.IServices;
using TheCoffeeCatStore.Mapper;

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
            var order = _order.GetOrderById(id);

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
                if (_order.GetOrderById(id) == null)
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

        [HttpPost]
        public ActionResult<Order> AddNewOrder([FromBody] List<OrderDetailCreateDTO> listOrderDetailDtos, Guid? CPID, Guid StaffID)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new OrderDetailProfile());
            });
            var mapper = config.CreateMapper();

            var listOrderDetails = listOrderDetailDtos.Select(o => mapper.Map<OrderDetailCreateDTO, OrderDetail>(o));
            //  var config = new MapperConfiguration(
            //    cfg => cfg.AddProfile(new OrderProfile())
            //);
            //  // create mapper
            //  var mapper = config.CreateMapper();


            //  var order = mapper.Map<Order>(ordercreateDTO);
            //_order.AddNewOrderByListOrderDetail(listOrderDetails.ToList(), CPID, StaffID);


            return Ok("Create Successfully");
        }

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
