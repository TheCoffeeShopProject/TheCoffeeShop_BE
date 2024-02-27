using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCoffeeCatBusinessObject.DTO;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatService.IServices;

namespace TheCoffeeCatStore.Controllers.SubscriptionsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISubscriptionServices _subscription;
        public SubscriptionsController(IMapper mapper, ISubscriptionServices subscription)
        {
            _mapper = mapper;
            _subscription = subscription;
        }
        [HttpGet]
        public ActionResult<Subscription> GetSubscriptions()
        {
            try {


                var subscriptions = _subscription.GetSubscriptions();
                var response = _mapper.Map<List<SubscriptionDTO>>(subscriptions);
                return Ok(response);

            } catch (Exception ex)

            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet]
        [Route("{id:Guid}")]
        public ActionResult GetSubscriptionById(Guid id)

        {

            try
            {
                var subscriptions = _subscription.GetSubscriptionById(id);

                if (subscriptions == null)
                {
                    return NotFound();
                }

                var response = _mapper.Map<SubscriptionDTO>(subscriptions);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("search")]
        public ActionResult<Subscription> GetSubscriptionByName(string searchvalue)
        {

            try
            {
                var subscriptions = _subscription.GetSubscriptionByName(searchvalue);
                var response = _mapper.Map<List<SubscriptionDTO>>(subscriptions);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult AddSubscription([FromForm] SubscriptionDTO subscriptionDTO)
        {
            try
            {
                var response = _mapper.Map<Subscription>(subscriptionDTO);
                _subscription.AddSubscription(response);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateSubscription([FromRoute] Guid id, [FromForm] SubscriptionDTO subscriptionDTO)
        {

            try
            {

                var subscription = _subscription.GetSubscriptionById(id);
                if (subscriptionDTO.Name != null)
                {
                    subscription.Name = subscriptionDTO.Name;
                }
                if (subscriptionDTO.Status != null)
                {
                    subscription.Status = subscriptionDTO.Status;
                }

 

                if (subscriptionDTO.DiscountPercent != null)
                {
                    subscription.DiscountPercent = subscriptionDTO.DiscountPercent;
                }

                if (subscriptionDTO.Price != null)
                {
                    subscription.Price = subscriptionDTO.Price;
                }

                _subscription.UpdateSubscription(subscription);


            }
            catch (DbUpdateConcurrencyException)
            {
                if (_subscription.GetSubscriptionById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Update Successfully");



        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteSubscription([FromRoute] Guid id)
        {
            var res= _subscription.GetSubscriptions();
            if(res == null)
            {
                return NotFound();
            }
            var res2 = _subscription.GetSubscriptionById(id);
            if(res2 == null)
            {
                return NotFound();
            }    
            _subscription.ChangeStatus(res2);
            return Ok("Delete Subcription Success");


        }




    }
}
