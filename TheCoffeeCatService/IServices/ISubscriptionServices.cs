using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;

namespace TheCoffeeCatService.IServices
{
    public interface ISubscriptionServices
    {
        public List<Subscription> GetSubscriptions();
        public Subscription GetSubscriptionById(Guid id);
        public IQueryable<Subscription> GetSubscriptionByName(string name);
        public void AddSubscription(Subscription subscription);
        public void UpdateSubscription(Subscription subscription);
        public bool ChangeStatus(Subscription subscription);
        
    }
}
