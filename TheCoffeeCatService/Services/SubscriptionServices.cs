using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatRepository.IRepository;
using TheCoffeeCatService.IServices;

namespace TheCoffeeCatService.Services
{
    public class SubscriptionServices : ISubscriptionServices
    {
        private ISubscriptionRepo _subscriptionRepo;
        public SubscriptionServices(ISubscriptionRepo subscriptionRepo)
        {
            _subscriptionRepo = subscriptionRepo;
        }
        public void AddSubscription(Subscription subscription)
        {
            _subscriptionRepo.AddSubscription(subscription);
        }

        public bool ChangeStatus(Subscription subscription)
        {
            return _subscriptionRepo.ChangeStatus(subscription);
        }

        public Subscription GetSubscriptionById(Guid id)
        {
            return _subscriptionRepo.GetSubscriptionById(id);
        }

        public IQueryable<Subscription> GetSubscriptionByName(string name)
        {
            return _subscriptionRepo.SearchSubscriptionByname(name);
        }

        public List<Subscription> GetSubscriptions()
        {
            return _subscriptionRepo.GetSubscriptions();
        }

        public void UpdateSubscription(Subscription subscription)
        {
             _subscriptionRepo.UpdateSubscription(subscription);
        }
    }
}
