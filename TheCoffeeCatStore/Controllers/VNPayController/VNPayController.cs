using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatDAO.DAOs;
using TheCoffeeCatService.IServices;
using TheCoffeeCatStore.Mapper;

namespace TheCoffeeCatStore.Controllers.VNPayController
{
    [Route("api/[controller]")]
    [ApiController]
    public class VNPayController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVnPayService _vnPayService;
        private readonly IOrderServices _orderServices;
        private readonly IOrderDetailServices _orderDetailServices;

        public VNPayController(IMapper mapper, IVnPayService vnPayService, IOrderServices orderServices, IOrderDetailServices orderDetailServices)
        {
            _mapper = mapper;
            _vnPayService = vnPayService;
            _orderServices = orderServices;
            _orderDetailServices = orderDetailServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentUrl(PaymentInformationModel model)
        {
            var url = _vnPayService.CreatePaymentUrl(model, HttpContext);

            return Ok(url);
        }

        [HttpGet("Check")]
        public async Task<IActionResult> PaymentCallback()
        {
            var response = _vnPayService.PaymentExecute(Request.Query);
            Guid userId = Guid.Parse(HttpContext.Request.Query["UserID"]);
            var model = _vnPayService.GetPaymentModelFromCache(userId); // Corrected method call
            if (response.Success == true)
            {
                Order order = new Order
                {
                    CustomerID = userId,
                    CreateTime = model.CreateTime,
                    TotalPrice = model.TotalPrice,
                    TotalItem = model.TotalItem,
                    TotalDiscount = model.TotalDiscount,
                    Status = true,
                    TableID = model.tableID,
                    CPID = model.CPID,
                    StaffID = model.StaffID
                };

                _orderServices.AddNewOrder(order);
                Guid orderID = order.OrderID;
                foreach (var orderDetail in model.orderDetails)
                {

                    var config = new MapperConfiguration(
                      cfg => cfg.AddProfile(new OrderDetailProfile())
                  );
                    // create mapper
                    var mapper = config.CreateMapper();


                    var orderdetail = mapper.Map<OrderDetail>(orderDetail);
                    orderdetail.OrderID = orderID;

                    _orderDetailServices.AddNew(orderdetail);
                }

                return Redirect("http://localhost:3000/admin?message=true");
            }
            else
            {
                // Payment failed, handle accordingly
                // Redirect to a failure page or return an error response
                return Redirect("http://localhost:3000/admin?message=false");
            }
        }
    }
}
